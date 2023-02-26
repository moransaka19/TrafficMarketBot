using System.Reflection;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using TelegramBotCore.AppConfiguration;
using TelegramBotCore.Clients;
using TelegramBotCore.Clients.Models;
using TelegramBotCore.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var env = builder.Environment.EnvironmentName;
builder.Configuration.AddJsonFile($"appsettings.{env}.json");
builder.Services.AddTelegramBot(builder.Configuration, Assembly.GetExecutingAssembly());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("/webhook", async (
    [FromBody] string updateJson,
    IRouteService routeService,
    ICommandFactory commandFactory) =>
{
    var jsonOptions = new JsonSerializerOptions
    {
        PropertyNamingPolicy = new SnakeCaseNamingPolicy()
    };
    
    var update = JsonSerializer.Deserialize<UpdateMessageModel>(updateJson, jsonOptions);
    
    var messageText = update.Message.Text;
    var commandPrefix = routeService.GetCommandPrefix(messageText);
    var command = commandFactory.Create(commandPrefix);

    await command.Execute(update);

    return Results.Ok();
});

app.MapGet("/webhook/{url}", async (
    [FromRoute] string url,
    TelegramClient telegramClient) =>
{
    var model = new SetWebhookRequestModel
    {
        Url = $"https://{url}/webhook"
    };
    await telegramClient.SetWebhookAsync(model);

    return Results.Ok();
});

app.Run();
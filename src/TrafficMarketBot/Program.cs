using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using TelegramBotCore.AppConfiguration;
using TelegramBotCore.Clients;
using TelegramBotCore.Clients.Models;
using TelegramBotCore.Services.Interfaces;
using JsonOptions = Microsoft.AspNetCore.Http.Json.JsonOptions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTelegramBot(builder.Configuration, Assembly.GetExecutingAssembly());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<JsonOptions>(op =>
{
    op.SerializerOptions.PropertyNamingPolicy = new SnakeCaseNamingPolicy();
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("/webhook", async (
    [FromBody] UpdateMessageModel update,
    IRouteService routeService,
    ICommandFactory commandFactory) =>
{
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
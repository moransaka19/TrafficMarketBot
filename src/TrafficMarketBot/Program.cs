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

// if (app.Environment.IsDevelopment())
// {
app.UseSwagger();
app.UseSwaggerUI();
// }

app.MapPost("/webhook", async (
    [FromBody] UpdateMessageModel update,
    ILogger<Program> logger,
    IRouteService routeService,
    ICommandFactory commandFactory) =>
{
    logger.LogInformation("Webhook requested");
    
    logger.LogInformation("Message was deserialized successfully");
    var messageText = update.Message.Text;
    var commandPrefix = routeService.GetCommandPrefix(messageText);
    var command = commandFactory.Create(commandPrefix);
    logger.LogInformation("Command was created");
    await command.Execute(update);

    return Results.Ok();
});

app.MapPost("/set-webhook", async (
    [FromBody] SetWebhookRequestModel model,
    TelegramClient telegramClient) =>
{
    await telegramClient.SetWebhookAsync(model);

    return Results.Ok();
});

app.Run();
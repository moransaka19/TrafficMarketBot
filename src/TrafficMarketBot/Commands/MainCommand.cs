using TelegramBotCore.Clients;
using TelegramBotCore.Clients.Models;
using TelegramBotCore.Data;
using TelegramBotCore.Services;
using TelegramBotCore.Services.Interfaces;

namespace TrafficMarketBot.Commands;

public class MainCommand: IBotCommand
{
    private readonly TelegramClient _telegramClient;
    private readonly ICommandStorageService _storageService;
    
    public MainCommand(
        TelegramClient telegramClient,
        ICommandStorageService storageService)
    {
        _telegramClient = telegramClient;
        _storageService = storageService;
    }

    public async Task Execute(UpdateMessageModel update)
    {
        var message = new MessageBuilder(update.Message.Chat.Id)
            .SetTextMessage("Welcome to main page")
            .AddButtonRow(x => x.AddButton("Test"))
            .Build();
        await _storageService.SetPreviousCommand(update.Message.From.Username, nameof(MainCommand));
        await _telegramClient.SendMessageAsync(message);
    }
}
using TelegramBotCore.Clients;
using TelegramBotCore.Clients.Models;
using TelegramBotCore.Services.Interfaces;

namespace TrafficMarketBot.Commands;

public class NotFoundCommand : IBotCommand
{
    private readonly TelegramClient _telegramClient;

    public NotFoundCommand(TelegramClient telegramClient)
    {
        _telegramClient = telegramClient;
    }

    public async Task Execute(UpdateMessageModel update)
    {
        // To main menu
    }
}
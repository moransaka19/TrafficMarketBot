using TelegramBotCore.Clients;
using TelegramBotCore.Clients.Models;
using TelegramBotCore.Services;
using TelegramBotCore.Services.Interfaces;

namespace TrafficMarketBot.Commands;

public class TestCommand : IBotCommand
{
    private readonly TelegramClient _telegramClient;

    public TestCommand(TelegramClient telegramClient)
    {
        _telegramClient = telegramClient;
    }

    public async Task Execute(UpdateMessageModel update)
    {
        var message = new MessageBuilder(update.Message.Chat.Id)
            .SetTextMessage("Test page")
            .AddButtonRow(x => x.AddButton("Назад"))
            .Build();

        await _telegramClient.SendMessageAsync(message);
    }
}
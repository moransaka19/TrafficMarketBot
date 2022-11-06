using TrafficMarketBot.Clients;
using TrafficMarketBot.Controllers.Models;

namespace TrafficMarketBot.Commands;

public class TestCommand : BaseCommand, ICommand
{
    public TestCommand(ITelegramClient telegramClient) : base(telegramClient)
    {
    }

    public async Task Execute(long chatId, long messageId)
    {
        Init(chatId, messageId);
        await BuildAndSendAsync("Welcome to Test page", new[]
        {
            new[]
            {
                new KeyboardButton("main")
            }
        });
    }
}
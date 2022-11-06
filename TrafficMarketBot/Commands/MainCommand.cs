using TrafficMarketBot.Clients;
using TrafficMarketBot.Controllers.Models;

namespace TrafficMarketBot.Commands;

public class MainCommand: BaseCommand, ICommand
{
    public MainCommand(ITelegramClient telegramClient) : base(telegramClient)
    {
    }
    
    public async Task Execute(long chatId, long messageId)
    {
        Init(chatId, messageId);
        await BuildAndSendAsync("Welcome to Main page", new[]
        {
            new[]
            {
                new KeyboardButton("test")
            }
        });
    }
}
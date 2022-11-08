using TrafficMarketBot.Clients;

namespace TrafficMarketBot.Commands;

public class CategoryCommand : BaseCommand, ICommand
{
    public CategoryCommand(ITelegramClient telegramClient) : base(telegramClient)
    {
    }

    public async Task Execute(long chatId, long messageId)
    {
        Init(chatId, messageId);

        var message = new MessageBuilder(chatId)
            .SetTextMessage("Category Page")
            .Build();
        
        await SendMessageAsync(message);
    }
}
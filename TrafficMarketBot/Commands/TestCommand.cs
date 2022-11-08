using TrafficMarketBot.Clients;
using TrafficMarketBot.Commands.Interfaces;

namespace TrafficMarketBot.Commands;

public class TestCommand : BaseCommand, ICommand
{
    public TestCommand(ITelegramClient telegramClient) : base(telegramClient)
    {
    }

    public async Task Execute(long chatId, long messageId)
    {
        Init(chatId, messageId);
		var message = new MessageBuilder(chatId)
			.SetTextMessage("Welcome to Test page")
			.AddButtonRow(x => x.AddButton("main"))
			.Build();
		await SendMessageAsync(message);
    }
}
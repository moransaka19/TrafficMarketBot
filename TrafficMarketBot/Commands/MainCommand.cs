using TrafficMarketBot.Clients;
using TrafficMarketBot.Commands.Interfaces;

namespace TrafficMarketBot.Commands;

public class MainCommand : BaseCommand, ICommand
{
	public MainCommand(ITelegramClient telegramClient) : base(telegramClient)
	{
	}

	public async Task Execute(long chatId, long messageId)
	{
		Init(chatId, messageId);
		var message = new MessageBuilder(chatId)
			.SetTextMessage("Welcome to Main page!")
			.AddButtonRow(x => x.AddButton("1").AddButton("2"))
			.AddButtonRow(x => x.AddButton("3").AddButton("4").AddButton("5"))
			.AddButtonRow(x => x.AddButton("6"))
			.Build();
		await SendMessageAsync(message);
	}
}

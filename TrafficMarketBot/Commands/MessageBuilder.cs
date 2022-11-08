using TrafficMarketBot.Commands.Interfaces;
using TrafficMarketBot.Controllers.Models;

namespace TrafficMarketBot.Commands;

public class MessageBuilder : IMessageBuilder
{
	private List<ButtonRow> _buttonRows;
	private string _textMessage;
	private readonly long _chatId;

	public MessageBuilder(long chatId)
	{
		_buttonRows = new List<ButtonRow>();
		_textMessage = string.Empty;
		_chatId = chatId;
	}

	public IMessageBuilder SetTextMessage(string text)
	{
		_textMessage = text;

		return this;
	}

	public IMessageBuilder AddButtonRow(Action<IButtonRow> buttonRow)
	{
		ArgumentNullException.ThrowIfNull(buttonRow);
		var row = new ButtonRow();
		buttonRow(row);
		_buttonRows.Add(row);

		return this;
	}

	public SendMessageModel Build()
	{
		var keyboard = _buttonRows.Select(x => x.Buttons.ToArray()).ToArray();
		
		return new SendMessageModel
		{
			ChatId = _chatId,
			Text = _textMessage,
			ReplyMarkup = new ReplyKeyboardMarkup
			{
				Keyboard = keyboard,
				OneTimeKeyboard = true,
				ResizeKeyboard = true
			}
		};
	}
}

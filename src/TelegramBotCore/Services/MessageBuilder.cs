using TelegramBotCore.Clients.Models;
using TelegramBotCore.Services.Interfaces;
using TrafficMarketBot.Commands.Interfaces;

namespace TelegramBotCore.Services;

public class MessageBuilder : IMessageBuilder
{
	private readonly List<ButtonRow> _buttonRows;
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
	
	public IMessageBuilder AddReturnButton()
	{
		var row = new ButtonRow
		{
			Buttons = { new KeyboardButton("назад") }
		};
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

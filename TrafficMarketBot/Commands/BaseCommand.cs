using TrafficMarketBot.Clients;
using TrafficMarketBot.Controllers.Models;

namespace TrafficMarketBot.Commands;

public abstract class BaseCommand
{
    private readonly ITelegramClient _telegramClient;
    private SendMessageModel _message;
    private long _chatId;
    private long _messageId;

    protected BaseCommand(ITelegramClient telegramClient)
    {
        _telegramClient = telegramClient;
    }

    protected void Init(long chatId, long messageId)
    {
        _chatId = chatId;
        _messageId = messageId;
    }
    
    // TODO: Make a fluent API in future
    // protected static Task Build(this BaseCommand, )

    protected async Task BuildAndSendAsync(
        string text,
        KeyboardButton[][] keyboardButton)
    {
        CreateSendMessageModel(text, keyboardButton);
        await Send();
        await DeleteUserCommandMessage();
    }
    
    private void CreateSendMessageModel(
        string text,
        KeyboardButton[][] keyboardButton)
    {
        _message = new SendMessageModel
        {
            Text = text,
            ChatId = _chatId,
            ReplyMarkup = new ReplyKeyboardMarkup
            {
                Keyboard = keyboardButton,
                ResizeKeyboard = true,
                OneTimeKeyboard = true,
            }
        };
    }

    private async Task Send()
    {
        var message = await _telegramClient.SendMessageAsync(_message);
    }

    private async Task DeleteUserCommandMessage()
    {
        await _telegramClient.DeleteMessageAsync(new DeleteMessageModel
        {
            ChatId = _chatId,
            MessageId = _messageId
        });
    }
}
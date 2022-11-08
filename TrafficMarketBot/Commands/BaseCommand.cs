using TrafficMarketBot.Clients;
using TrafficMarketBot.Controllers.Models;

namespace TrafficMarketBot.Commands;

public abstract class BaseCommand
{
    private readonly ITelegramClient _telegramClient;
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
    
    protected async Task SendMessageAsync(SendMessageModel model)
    {
        var message = await _telegramClient.SendMessageAsync(model);
    }

	//TODO: Need test It!
    private async Task DeleteUserCommandMessage()
    {
        await _telegramClient.DeleteMessageAsync(new DeleteMessageModel
        {
            ChatId = _chatId,
            MessageId = _messageId
        });
    }
}
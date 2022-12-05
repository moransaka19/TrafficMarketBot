using TelegramBotCore.Clients.Models;
using TelegramBotCore.Data;
using TelegramBotCore.Services.Interfaces;

namespace TrafficMarketBot.Commands;

public class ReturnCommand: IBotCommand
{
    private readonly ICommandStorageService _commandStorage;
    
    public ReturnCommand(ICommandStorageService commandStorage)
    {
        _commandStorage = commandStorage;
    }

    public async Task Execute(UpdateMessageModel update)
    {
        var command = await _commandStorage.GetPreviousCommand(update.Message.From.Username);
        await command.Execute(update);
    }
}
using TelegramBotCore.Clients.Models;
using TelegramBotCore.Services.Interfaces;

namespace TrafficMarketBot.Commands;

public class StartCommand: IBotCommand
{
    private readonly ICommandFactory _commandFactory;
    
    public StartCommand(
        ICommandFactory commandFactory)
    {
        _commandFactory = commandFactory;
    }

    public async Task Execute(UpdateMessageModel update)
    {
        var command = _commandFactory.Create(nameof(MainCommand));
        await command.Execute(update);
    }
}
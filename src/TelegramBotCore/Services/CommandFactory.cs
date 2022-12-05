using System.Collections.Immutable;
using Microsoft.Extensions.DependencyInjection;
using TelegramBotCore.Services.Interfaces;

namespace TelegramBotCore.Services;

public class CommandFactory : ICommandFactory
{
    private readonly ImmutableArray<Type> _commandTypes;
    private readonly IServiceProvider _serviceProvider;

    public CommandFactory(
        IServiceProvider serviceProvider,
        ImmutableArray<Type> commandTypes)
    {
        _commandTypes = commandTypes;
        _serviceProvider = serviceProvider;
    }

    public IBotCommand Create(string commandName)
    {
        var commandType = _commandTypes.FirstOrDefault(x => x.Name == commandName);

        if (commandType is null)
        {
            //TODO: Add logger
            return null;
        }

        return (IBotCommand)_serviceProvider.GetRequiredService(commandType);
    }
}
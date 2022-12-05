using System.Text;
using Microsoft.Extensions.Caching.Distributed;
using TelegramBotCore.Services.Interfaces;

namespace TelegramBotCore.Data;

public class CommandStorageServiceService : ICommandStorageService
{
    private readonly IDistributedCache _distributedCache;
    private readonly ICommandFactory _commandFactory;

    public CommandStorageServiceService(
        IDistributedCache distributedCache,
        ICommandFactory commandFactory)
    {
        _distributedCache = distributedCache;
        _commandFactory = commandFactory;
    }

    public async Task<IBotCommand> GetPreviousCommand(string username)
    {
        var commandTypeName = await _distributedCache.GetAsync(username);

        if (commandTypeName == null)
        {
            //TODO: Add logger
            return _commandFactory.Create("StartCommand")!;
        }

        var previousCommandPrefixName = Encoding.UTF8.GetString(commandTypeName);

        return _commandFactory.Create(previousCommandPrefixName);
    }

    public async Task SetPreviousCommand(string username, string commandTypeName)
    {
        await _distributedCache.SetAsync(username, Encoding.UTF8.GetBytes(commandTypeName));
    }
}
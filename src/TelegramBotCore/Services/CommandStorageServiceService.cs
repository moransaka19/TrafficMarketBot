using System.Text;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using TelegramBotCore.Data;
using TelegramBotCore.Services.Interfaces;

namespace TelegramBotCore.Services;

public class CommandStorageServiceService : ICommandStorageService
{
    private readonly IDistributedCache _distributedCache;
    private readonly ICommandFactory _commandFactory;
    private readonly ILogger<CommandStorageServiceService> _logger;

    public CommandStorageServiceService(
        IDistributedCache distributedCache,
        ICommandFactory commandFactory,
        ILogger<CommandStorageServiceService> logger)
    {
        _distributedCache = distributedCache;
        _commandFactory = commandFactory;
        _logger = logger;
    }

    public async Task<IBotCommand> GetPreviousCommand(string username)
    {
        var commandTypeName = await _distributedCache.GetAsync(username);

        if (commandTypeName == null)
        {
            _logger.LogWarning("Previous command is not found for user {username}");
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
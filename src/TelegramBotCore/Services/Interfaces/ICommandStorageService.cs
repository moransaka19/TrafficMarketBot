using TelegramBotCore.Services.Interfaces;

namespace TelegramBotCore.Data;

public interface ICommandStorageService
{
    Task<IBotCommand> GetPreviousCommand(string username);
    Task SetPreviousCommand(string username, string commandTypeName);
}
namespace TelegramBotCore.Services.Interfaces;

public interface ICommandFactory
{
    IBotCommand Create(string commandName);
}
namespace TelegramBotCore.Services.Interfaces;

public interface IRouteService
{
    string GetCommandPrefix(string messageText);
}
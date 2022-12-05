using TelegramBotCore.Services.Interfaces;

namespace TelegramBotCore.Services;

public class RouteService : IRouteService
{
    public string GetCommandPrefix(string messageText)
    {
        // TODO: Store in distributed cache
        var routes = new Dictionary<string, string>
        {
            {"/start", "StartCommand"},
            {"Test", "TestCommand"},
            {"main", "MainCommand"},
            {"Назад", "ReturnCommand"},
        };

        if (!routes.TryGetValue(messageText, out var routeValue))
        {
            // TODO: Add logger
            return "NotFoundCommand";
        }

        return routeValue;
    }
}
using Microsoft.Extensions.Logging;
using TelegramBotCore.Services.Interfaces;

namespace TelegramBotCore.Services;

public class RouteService : IRouteService
{
    private readonly ILogger<RouteService> _logger;

    public RouteService(ILogger<RouteService> logger)
    {
        _logger = logger;
    }

    public string GetCommandPrefix(string messageText)
    {
        var routes = new Dictionary<string, string>
        {
            {"/start", "StartCommand"},
            {"Test", "TestCommand"},
            {"main", "MainCommand"},
            {"Назад", "ReturnCommand"},
        };

        if (!routes.TryGetValue(messageText, out var routeValue))
        {
            _logger.LogWarning("Command with name {messageText} not found", messageText);
            return "NotFoundCommand";
        }

        return routeValue;
    }
}
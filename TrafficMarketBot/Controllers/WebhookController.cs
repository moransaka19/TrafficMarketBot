using Microsoft.AspNetCore.Mvc;
using TrafficMarketBot.Commands;

namespace TrafficMarketBot.Controllers;

[Route("webhook")]
[ApiController]
public class WebhookController : Controller
{
    private readonly IServiceProvider _serviceProvider;

    public WebhookController(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Update update)
    {
        var routeKey = update.Message.Text;

        var routes = new Dictionary<string, string>
        {
            {"test", "Test"},
            {"main", "Main"},
        };

        if (!routes.TryGetValue(routeKey, out var routeValue))
        {
            // TODO: Implement ErrorCommand
        }

        var commandName = routeValue + "Command";
        var commandFullname = $"{typeof(ICommand).Namespace}.{commandName}";
        var commandType = typeof(ICommand).Assembly.GetType(commandFullname, true);
        
        if (commandType is null)
        {
            return BadRequest();
        }

        var command = (ICommand)_serviceProvider.GetRequiredService(commandType);
        var chatId = update.Message.Chat.Id;
        var messageId = update.Message.MessageId;
        await command.Execute(chatId, messageId);
        
        return Ok();

    }
}
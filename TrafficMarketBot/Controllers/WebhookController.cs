using Microsoft.AspNetCore.Mvc;
using TrafficMarketBot.Clients;
using TrafficMarketBot.Commands;

namespace TrafficMarketBot.Controllers;

[Route("webhook")]
[ApiController]
public class WebhookController : Controller
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ITelegramClient _telegramClient;

    public WebhookController(
        IServiceProvider serviceProvider,
        ITelegramClient telegramClient)
    {
        _serviceProvider = serviceProvider;
        _telegramClient = telegramClient;
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
            return Ok();
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

    [HttpGet("{url}")]
    public async Task<IActionResult> SetWebhook([FromRoute] string url)
    {
        var model = new SetWebhookRequestModel
        {
            Url = $"https://{url}/webhook"
        };
        var t = await _telegramClient.SetWebhookAsync(model);
    
        return Ok();
    }
}
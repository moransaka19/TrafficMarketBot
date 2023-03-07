using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TelegramBotCore.Clients.Models;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class SetWebhookRequestModel
{
    public string Url { set; get; } = null!;
}
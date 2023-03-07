using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TelegramBotCore.Clients.Models;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class UpdateMessageModel
{
    public int UpdateId { get; set; }
    public Message Message { get; set; } = null!;
} 
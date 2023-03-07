using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TelegramBotCore.Clients.Models;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class CreatedMessageModel
{
    public bool Ok { get; set; }
    public Message Result { get; set; } = null!;
}
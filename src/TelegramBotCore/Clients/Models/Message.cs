using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TelegramBotCore.Clients.Models;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class Message
{
    public long MessageId { get; set; }
    public From From { get; set; } = null!;
    public Chat Chat { get; set; } = null!;
    public string Text { get; set; } = null!;
    public int Date { get; set; }
}
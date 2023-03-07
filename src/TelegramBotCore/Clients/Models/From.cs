using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TelegramBotCore.Clients.Models;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class From
{
    public long Id { get; set; }
    public bool IsBot { get; set; }
    public string FirstName { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string LanguageCode { get; set; } = null!;
}
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TelegramBotCore.Clients.Models;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class SendMessageModel
{
    public long ChatId { get; set; }
    public string Text { get; set; } = null!;
    public string ParseMode { get; set; } = null!;
    public bool DisableWebPagePreview { get; set; }
    public bool DisableNotification { get; set; }
    public long ReplyToMessageId { get; set; }
    public ReplyKeyboardMarkup ReplyMarkup { get; set; } = null;
}   
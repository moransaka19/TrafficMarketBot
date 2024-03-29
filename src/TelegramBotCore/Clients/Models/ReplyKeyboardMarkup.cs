using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TelegramBotCore.Clients.Models;

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class ReplyKeyboardMarkup
{
    public KeyboardButton[][] Keyboard { get; set; } = null!;
    public bool OneTimeKeyboard { get; set; }
    public bool ResizeKeyboard { get; set; }
    public string InputFieldPlaceholder { get; set; } = null!;
    public bool Selective { get; set; }
}

[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class KeyboardButton
{
    public KeyboardButton(string text)
    {
        Text = text;
    }

    public string Text { get; set; }
    public bool RequestContact { get; set; }
    public bool RequestLocation { get; set; }
    public object RequestPoll { get; set; }
    public object WebApp { get; set; }
}
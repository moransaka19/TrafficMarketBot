namespace TelegramBotCore.Clients.Models;

public class ReplyKeyboardMarkup
{
    public KeyboardButton[][] Keyboard { get; set; }
    public bool OneTimeKeyboard { get; set; }
    public bool ResizeKeyboard { get; set; }
    public string InputFieldPlaceholder { get; set; }
    public bool Selective { get; set; }
}

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
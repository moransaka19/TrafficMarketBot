namespace TelegramBotCore.Clients.Models;

public class SendMessageModel
{
    public long ChatId { get; set; }
    public string Text { get; set; }
    public string ParseMode { get; set; }
    public bool DisableWebPagePreview { get; set; }
    public bool DisableNotification { get; set; }
    public long ReplyToMessageId { get; set; }
    public ReplyKeyboardMarkup ReplyMarkup { get; set; }
}   
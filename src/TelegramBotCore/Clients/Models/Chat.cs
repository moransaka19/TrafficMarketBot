namespace TelegramBotCore.Clients.Models;

public class Chat
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string Username { get; set; }
    public string Type { get; set; }
    public bool IsBot { get; set; }
}
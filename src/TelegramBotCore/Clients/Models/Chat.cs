namespace TelegramBotCore.Clients.Models;

public class Chat
{
    public long Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string Type { get; set; } = null!;
    public bool IsBot { get; set; }
}
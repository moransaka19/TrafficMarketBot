namespace DAL.Entities;

public class Client
{
    public int Id { get; set; }
    public string TelegramId { get; set; }
    public string Username { get; set; }

    public List<Announcement> Announcements { get; set; }
}
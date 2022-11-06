namespace DAL.Entities;
using DAL.Entities.Enums;

public class Announcement
{
    public long Id { get; set; }
    public int UserId { get; set; }

    public string Header { get; set; }
    public string Description { get; set; }
    public AnnouncementType Type { get; set; }
}
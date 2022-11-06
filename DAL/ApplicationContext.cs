namespace DAL;

using Microsoft.EntityFrameworkCore;
using DAL.Entities;

public class ApplicationContext : DbContext
{
    public DbSet<Client> Users { get; set; }
    public DbSet<Announcement> Announcements { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>()
            .HasKey(x => x.Id);
        modelBuilder.Entity<Client>()
            .Property(x => x.TelegramId);
        modelBuilder.Entity<Client>()
            .Property(x => x.Username);
        modelBuilder.Entity<Client>()
            .HasMany<Announcement>();

        modelBuilder.Entity<Announcement>()
            .HasKey(x => x.Id);
        modelBuilder.Entity<Announcement>()
            .Property(x => x.Header);
        modelBuilder.Entity<Announcement>()
            .Property(x => x.Type);
        modelBuilder.Entity<Announcement>()
            .Property(x => x.Description);
        modelBuilder.Entity<Announcement>();

        base.OnModelCreating(modelBuilder);
    }
}
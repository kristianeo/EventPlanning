using EventPlanning.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlanning;

public class EventDbContext(DbContextOptions<EventDbContext> options) : DbContext(options)
{
    public DbSet<Event> Events => Set<Event>();
    public DbSet<User> Users => Set<User>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(user =>
        {
            user.HasKey(u => u.Id);

            user.Property(u => u.FirstName).IsRequired().HasMaxLength(100);
            user.Property(u => u.LastName).IsRequired().HasMaxLength(100);
            user.Property(u => u.Email).HasMaxLength(320);
            user.Property(u => u.Auth0Id).HasMaxLength(200);
            
            user.HasIndex(u => u.Auth0Id).IsUnique();
            
            user.HasMany(u => u.Owned)
                .WithOne(e => e.Owner)
                .HasForeignKey(e => e.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Event>(ev =>
        {
            ev.HasKey(e => e.Id);

            ev.Property(e => e.Title).IsRequired().HasMaxLength(200);
            ev.Property(e => e.Location).IsRequired().HasMaxLength(300);
            ev.Property(e => e.Description).HasMaxLength(4000);
            ev.Property(e => e.Date).IsRequired();

            ev.HasIndex(e => e.OwnerId);
            ev.HasIndex(e => e.Date);
        });
        
        // test user 
        modelBuilder.Entity<User>().HasData(new User
        {
            Id = 1,
            FirstName = "Dev",
            LastName = "User",
            Email = "dev@example.com"
        });
        
        modelBuilder.Entity<Participant>(p =>
        {
            p.HasKey(x => x.Id);

            p.Property(x => x.Email).HasMaxLength(320);

            p.Property(x => x.Status)
                .HasConversion<string>()
                .HasMaxLength(20)
                .HasDefaultValue(ParticipantStatus.Invited)
                .IsRequired();

            p.HasOne(x => x.Event)
                .WithMany(e => e.Participants)
                .HasForeignKey(x => x.EventId)
                .OnDelete(DeleteBehavior.Cascade);

            p.HasOne(x => x.User)
                .WithMany(u => u.Participations)
                .HasForeignKey(x => x.UserId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

            // One row per user per event, and one per email per event.
            // Postgres allows multiple NULLs in a unique index, so rows without a user or email don't clash.
            p.HasIndex(x => new { x.EventId, x.UserId }).IsUnique();
            p.HasIndex(x => new { x.EventId, x.Email }).IsUnique();
        });
    }
}
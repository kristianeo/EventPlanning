using Microsoft.EntityFrameworkCore;

namespace EventPlanning;

public class EventDbContext(DbContextOptions<EventDbContext> options) : DbContext(options)
{
    /*
    public DbSet<Product> Products => Set<Product>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(200);
    }*/
}
using Microsoft.EntityFrameworkCore;
using Wrongcat.Api.Model;

namespace Wrongcat.Api.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();
        modelBuilder.Entity<User>()
            .Property(u => u.Email)
            .HasMaxLength(256);
        
        modelBuilder.Entity<User>()
            .Property(u => u.Password)
            .HasMaxLength(512);
        
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Nickname)
            .IsUnique();
        modelBuilder.Entity<User>()
            .Property(u => u.Nickname)
            .HasMaxLength(32);
        
        modelBuilder.Entity<User>()
            .Property(u => u.ProfileImageUrl)
            .HasMaxLength(512);
        
        modelBuilder.Entity<User>()
            .Property(u => u.Bio)
            .HasMaxLength(512);
    }
}

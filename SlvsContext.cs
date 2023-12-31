using Microsoft.EntityFrameworkCore;
using SLVS.Database.Model;

namespace SLVS;

public class SlvsContext : DbContext
{
    public SlvsContext(DbContextOptions<SlvsContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<UserGroup> UserGroups { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<UserRecoveryToken> RecoveryTokens { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasMany<UserGroup>(u => u.UserGroups)
                .WithMany(ug => ug.Users);
            entity.HasMany<UserRecoveryToken>(u => u.RecoveryTokens)
                .WithOne(r => r.User);

            entity.HasData(new User { Id = 1, Lettercode = "SIEFA", Password = BCrypt.Net.BCrypt.HashPassword("test1234"), Email = "finley@siebertmedia.nl" });
        });

        modelBuilder.Entity<UserGroup>(entity =>
        {
            entity.HasMany(ug => ug.Permissions)
                .WithMany(p => p.UserGroups);

            entity.HasData(new UserGroup { Id = 1, Name = "User", Description = "Default user group" });
        });
    }
}
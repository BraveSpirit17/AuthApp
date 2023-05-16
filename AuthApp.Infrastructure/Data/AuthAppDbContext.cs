using AuthApp.Core.Entities;
using AuthApp.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace AuthApp.Infrastructure.Data;

public class AuthAppDbContext : DbContext
{
    public DbSet<ApplicationUser> Users { get; set; }

    public AuthAppDbContext(DbContextOptions<AuthAppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
    }
}
using AuthApp.Core.Entities;
using AuthApp.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace AuthApp.Infrastructure.Data;

public class AuthAppContext : DbContext
{
    public DbSet<ApplicationUser> Users { get; set; }

    public AuthAppContext(DbContextOptions<AuthAppContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
    }
}
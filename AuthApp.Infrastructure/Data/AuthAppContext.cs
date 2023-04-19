using AuthApp.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthApp.Infrastructure.Data;

public class AuthAppContext : DbContext
{
    public AuthAppContext()
    {
    }

    public AuthAppContext(DbContextOptions<AuthAppContext> options)
        : base(options)
    {
    }

    public DbSet<ApplicationUser> Users { get; set; }
}
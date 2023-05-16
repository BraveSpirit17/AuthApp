using AuthApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthApp.Infrastructure.Data.Configurations;

internal class UserEntityTypeConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.ToTable("Users");
        
        builder.Property(u => u.Id).ValueGeneratedOnAdd();
        builder.Property(u => u.UserName).HasMaxLength(50).IsRequired();
        builder.Property(u => u.Email).HasMaxLength(50).IsRequired();
    }
}
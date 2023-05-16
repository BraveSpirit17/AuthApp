using AuthApp.Core.Entities;
using AuthApp.Infrastructure.Data.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthApp.Infrastructure.Data.Configurations;

internal class UserEntityTypeConfiguration : BaseEntityTypeConfiguration<ApplicationUser>
{
    public override void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        base.Configure(builder);

        builder.ToTable("Users");

        builder.Property(u => u.Id).ValueGeneratedOnAdd();

        builder.Property(u => u.FirstName).HasMaxLength(50).IsRequired();
        builder.Property(u => u.LastName).HasMaxLength(50).IsRequired();
        builder.Property(u => u.MiddleName).HasMaxLength(50);
        
        builder.Property(u => u.MobilePhone).HasMaxLength(65);
        builder.Property(u => u.Email).HasMaxLength(110).IsRequired();
        
        builder.Property(u => u.UserName).HasMaxLength(50).IsRequired();
        builder.Property(u => u.PasswordHash).HasMaxLength(35).IsRequired();
    }
}
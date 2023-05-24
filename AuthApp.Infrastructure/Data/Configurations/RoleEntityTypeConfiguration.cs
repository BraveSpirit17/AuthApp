using AuthApp.Core.Entities;
using AuthApp.Infrastructure.Data.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthApp.Infrastructure.Data.Configurations;

internal class RoleEntityTypeConfiguration : BaseEntityTypeConfiguration<Role>
{
    public override void Configure(EntityTypeBuilder<Role> builder)
    {
        base.Configure(builder);

        builder.ToTable("Roles");
        
        builder.Property(r => r.Name).HasMaxLength(50);
    }
}
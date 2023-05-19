using AuthApp.Core.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthApp.Infrastructure.Data.Configurations.Base;

internal abstract class BaseEntityTypeConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : Entity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.Property(e => e.Id).ValueGeneratedOnAdd();
        builder.Property(e => e.CreateDate).HasDefaultValueSql("GETDATE()");
        builder.Property(e => e.UpdateDate).HasDefaultValueSql("GETDATE()");
    }
}
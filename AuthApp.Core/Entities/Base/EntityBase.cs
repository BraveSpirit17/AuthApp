namespace AuthApp.Core.Entities.Base;

public abstract class EntityBase<TId> : IEntityBase<TId>
{
    public TId Id { get; set; }
}
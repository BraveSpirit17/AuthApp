namespace AuthApp.Core.Entities.Base;

public abstract class Entity : EntityBase<Guid>
{
    public DateTime CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }
}
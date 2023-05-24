using AuthApp.Core.Entities.Base;

namespace AuthApp.Core.Entities;

public class Role : Entity
{
    public string Name { get; set; }

    public ICollection<ApplicationUser> Users { get; set; }
}
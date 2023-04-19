using AuthApp.Core.Entities.Base;

namespace AuthApp.Core.Entities;

public class ApplicationUser : Entity
{
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
}
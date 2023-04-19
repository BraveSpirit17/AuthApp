using System.ComponentModel.DataAnnotations.Schema;
using AuthApp.Core.Entities.Base;

namespace AuthApp.Core.Entities;

[Table("Users")]
public class ApplicationUser : Entity
{
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
}
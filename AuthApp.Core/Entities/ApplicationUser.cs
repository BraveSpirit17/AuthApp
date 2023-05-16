using AuthApp.Core.Entities.Base;

namespace AuthApp.Core.Entities;

public class ApplicationUser : Entity
{
    // public string FirstName { get; set; }
    //
    // public string LastName { get; set; }
    //
    // public string MiddleName { get; set; }

    public string UserName { get; set; }

    public string Email { get; set; }

    public string PasswordHash { get; set; }

    // public DateTime? BirthDate { get; set; }
    //
    // public bool IsBlocked { get; set; }
    //
    // public string? MobilePhone { get; set; }
    //
    // public bool IsSendEmail { get; set; }
}
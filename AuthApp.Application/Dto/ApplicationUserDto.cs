using AuthApp.Application.Dto.Base;

namespace AuthApp.Application.Dto;

public class ApplicationUserDto : BaseDto
{
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
}
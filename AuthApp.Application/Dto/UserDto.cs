using AuthApp.Application.Dto.Base;

namespace AuthApp.Application.Dto;

public class UserDto : BaseDto
{
    public string FullName { get; set; }

    public string UserName { get; set; }

    public string Email { get; set; }
}
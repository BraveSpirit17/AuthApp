using AuthApp.Application.Dto.Base;

namespace AuthApp.Application.Dto;

public class TokenDto : BaseDto
{
    public AccessTokenDto Token { get; set; }

    public TokenDto(bool success, string message, AccessTokenDto token) : base(success, message)
    {
        Token = token;
    }
}
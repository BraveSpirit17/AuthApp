using AuthApp.Application.Dto;

namespace AuthApp.Application.Interfaces;

public interface IAuthenticationService
{
    Task<TokenDto> CreateAccessTokenAsync(string userName, string password);
    Task<TokenDto> RefreshTokenAsync(string refreshToken, string userName);
}
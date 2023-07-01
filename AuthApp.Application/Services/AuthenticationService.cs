using System.Security.Claims;
using AuthApp.Application.Dto;
using AuthApp.Application.Interfaces;

namespace AuthApp.Application.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUserService _userService;
    private readonly ITokenService _tokenService;
    private readonly IPasswordHashingService _passwordHashingService;

    public AuthenticationService(IUserService userService, ITokenService tokenService,
        IPasswordHashingService passwordHashingService)
    {
        _userService = userService;
        _tokenService = tokenService;
        _passwordHashingService = passwordHashingService;
    }

    public async Task<TokenDto> CreateAccessTokenAsync(string userName, string password)
    {
        var user = await _userService.FindByUserNameAsync(userName);

        if (user == null || !_passwordHashingService.Validate(user.PasswordHash, password))
        {
            throw new Exception("Пароль введен неверно.");
            //return new TokenDto(string.Empty, false, "Invalid credentials.");
        }

        var claims = new List<Claim>(new[]
        {
            new Claim("userName", user.UserName),
            new Claim("email", user.Email)
        });
        
        var token = _tokenService.TokenGeneration(claims);

        return new TokenDto(token, true, string.Empty);
    }

    public Task<TokenDto> RefreshTokenAsync(string refreshToken, string userName)
    {
        throw new NotImplementedException();
    }
}
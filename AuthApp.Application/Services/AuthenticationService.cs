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
            return new TokenDto(string.Empty, false, "Invalid credentials.");
        }

        var token = _tokenService.TokenGeneration(user.UserName);

        return new TokenDto(token, true, string.Empty);
    }

    public Task<TokenDto> RefreshTokenAsync(string refreshToken, string userName)
    {
        throw new NotImplementedException();
    }
}
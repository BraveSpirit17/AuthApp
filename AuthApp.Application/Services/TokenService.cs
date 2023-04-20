using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AuthApp.Application.Dto;
using AuthApp.Application.Interfaces;
using AuthApp.Application.Options;
using AuthApp.Core.Repositories;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace AuthApp.Application.Services;

public class TokenService : ITokenService
{
    private const int ExpirationMinutes = 30;

    private readonly JwtOptions _jwtOptions;
    private readonly IUserRepository _userRepository;

    public TokenService(IUserRepository userRepository, IOptions<JwtOptions> options)
    {
        _userRepository = userRepository;
        _jwtOptions = options.Value;
    }

    public async Task<string> GetTokenAsync(ApplicationUserDto applicationUserDto,
        CancellationToken cancellationToken = default)
    {
        var expiration = DateTime.UtcNow.AddMinutes(ExpirationMinutes);

        var user = await _userRepository
            .GetUserAsync(applicationUserDto.UserName, applicationUserDto.Password, cancellationToken);

        //create claims details based on the user information
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, _jwtOptions.Subject),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
            new Claim("UserId", user.Id.ToString()),
            new Claim("UserName", user.UserName),
            new Claim("Email", user.Email)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Key));

        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            _jwtOptions.Issuer,
            _jwtOptions.Audience,
            claims,
            expires: expiration,
            signingCredentials: signIn);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
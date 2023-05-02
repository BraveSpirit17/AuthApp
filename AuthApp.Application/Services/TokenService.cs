using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AuthApp.Application.Interfaces;
using AuthApp.Application.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace AuthApp.Application.Services;

public class TokenService : ITokenService
{
    private const int ExpirationMinutes = 30;

    private readonly JwtOptions _jwtOptions;

    public TokenService(IOptions<JwtOptions> options)
    {
        _jwtOptions = options.Value;
    }

    public string TokenGeneration(string userName)
    {
        var expiration = DateTime.UtcNow.AddMinutes(ExpirationMinutes);

        //create claims details based on the user information
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, _jwtOptions.Subject),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
            new Claim("UserName", userName)
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
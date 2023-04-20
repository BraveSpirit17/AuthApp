using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AuthApp.Application.Dto;
using AuthApp.Application.Interfaces;
using AuthApp.Core.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace AuthApp.Application.Services;

internal class TokenService : ITokenService
{
    private const int ExpirationMinutes = 30;

    private readonly IConfiguration _configuration;
    private readonly IUserRepository _userRepository;

    public TokenService(IUserRepository userRepository, IConfiguration configuration)
    {
        _userRepository = userRepository;
        _configuration = configuration;
    }

    public async Task<string> GetTokenAsync(ApplicationUserDto applicationUserDto,
        CancellationToken cancellationToken = new())
    {
        var expiration = DateTime.UtcNow.AddMinutes(ExpirationMinutes);

        var user = await _userRepository
            .GetUserAsync(applicationUserDto.UserName, applicationUserDto.Password, cancellationToken);

        //create claims details based on the user information
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, _configuration["JwtOptions:Subject"]),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
            new Claim("UserId", user.Id.ToString()),
            new Claim("UserName", user.UserName),
            new Claim("Email", user.Email)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtOptions:Key"]));

        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            _configuration["JwtOptions:Issuer"],
            _configuration["JwtOptions:Audience"],
            claims,
            expires: expiration,
            signingCredentials: signIn);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace AuthApp.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    public readonly IConfiguration Configuration;

    public AuthController(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    
    [HttpPost]
    public async Task<IActionResult> GetToken(string login, string password)
    {
        //create claims details based on the user information
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, Configuration["JwtOptions:Subject"]),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
            new Claim("UserId", "123"),
            new Claim("DisplayName", "Name"),
            new Claim("UserName", "Login"),
            new Claim("Email", "Email")
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtOptions:Key"]));
        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            Configuration["JwtOptions:Issuer"],
            Configuration["JwtOptions:Audience"],
            claims,
            expires: DateTime.UtcNow.AddMinutes(10),
            signingCredentials: signIn);

        return Ok(new JwtSecurityTokenHandler().WriteToken(token));
    }
}
﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AuthApp.Application.Interfaces;
using AuthApp.Application.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace AuthApp.Application.Services;

internal class TokenService : ITokenService
{
    private const int ExpirationMinutes = 30;

    private readonly JwtOptions _jwtOptions;

    public TokenService(IOptions<JwtOptions> options)
    {
        _jwtOptions = options.Value;
    }

    public string TokenGeneration(List<Claim> claims)
    {
        var expiration = DateTime.UtcNow.AddMinutes(ExpirationMinutes);

        //create claims details based on the user information

        claims.Add(new(JwtRegisteredClaimNames.Sub, _jwtOptions.Subject));
        claims.Add(new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
        claims.Add(new(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()));

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Key));

        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(_jwtOptions.Issuer, _jwtOptions.Audience, claims, expires: expiration,
            signingCredentials: signIn);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
using System.Security.Claims;

namespace AuthApp.Application.Interfaces;

public interface ITokenService
{
    string TokenGeneration(List<Claim> claims);
}
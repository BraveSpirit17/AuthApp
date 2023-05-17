using AuthApp.Application.Dto;

namespace AuthApp.Application.Interfaces;

public interface ITokenService
{
    AccessTokenDto TokenGeneration(string userName);
}
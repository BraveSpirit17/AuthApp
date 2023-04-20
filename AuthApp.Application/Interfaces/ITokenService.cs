using AuthApp.Application.Dto;

namespace AuthApp.Application.Interfaces;

public interface ITokenService
{
    Task<string> GetTokenAsync(ApplicationUserDto applicationUserDto, CancellationToken cancellationToken = default);
}
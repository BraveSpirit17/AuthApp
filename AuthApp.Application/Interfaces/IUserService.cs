using AuthApp.Application.Dto;
using AuthApp.Core.Entities;

namespace AuthApp.Application.Interfaces;

public interface IUserService
{
    Task<UserDto> CreateUserAsync(ApplicationUser user);
    Task<ApplicationUser?> FindByUserNameAsync(string userName, CancellationToken cancellationToken = default);
}
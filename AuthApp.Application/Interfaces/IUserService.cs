using AuthApp.Core.Entities;

namespace AuthApp.Application.Interfaces;

public interface IUserService
{
    Task<ApplicationUser?> FindByUserNameAsync(string userName, CancellationToken cancellationToken = default);
}
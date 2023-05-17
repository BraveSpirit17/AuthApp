using AuthApp.Core.Entities;
using AuthApp.Core.Repositories.Base;

namespace AuthApp.Core.Repositories;

public interface IUserRepository : IRepository<ApplicationUser>
{
    Task<ApplicationUser?> FindByUserNameAsync(string userName, CancellationToken cancellationToken = default);
    
    Task<ApplicationUser?> FindByEmailAsync(string email, CancellationToken cancellationToken = default);
}
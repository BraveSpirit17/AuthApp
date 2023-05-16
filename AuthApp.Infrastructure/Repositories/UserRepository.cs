using AuthApp.Core.Entities;
using AuthApp.Core.Repositories;
using AuthApp.Infrastructure.Data;
using AuthApp.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace AuthApp.Infrastructure.Repositories;

internal class UserRepository : Repository<ApplicationUser>, IUserRepository
{
    private readonly AuthAppDbContext _dbContext;

    public UserRepository(AuthAppDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ApplicationUser?> GetUserAsync(string userName, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Users
            .FirstOrDefaultAsync(u => u.UserName == userName, cancellationToken);
    }
}
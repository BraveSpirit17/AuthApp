using AuthApp.Core.Entities;
using AuthApp.Core.Repositories;
using AuthApp.Infrastructure.Data;
using AuthApp.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace AuthApp.Infrastructure.Repositories;

public class UserRepository : Repository<ApplicationUser>, IUserRepository
{
    private readonly AuthAppContext _context;

    public UserRepository(AuthAppContext context) : base(context)
    {
        _context = context;
    }

    public async Task<ApplicationUser> GetUserAsync(string login, string password,
        CancellationToken cancellationToken = new())
    {
        return await _context.Users
            .FirstAsync(u => u.UserName == login && u.Password == password, cancellationToken);
    }
}
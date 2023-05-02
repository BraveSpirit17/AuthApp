﻿using AuthApp.Core.Entities;
using AuthApp.Core.Repositories.Base;

namespace AuthApp.Core.Repositories;

public interface IUserRepository : IRepository<ApplicationUser>
{
    Task<ApplicationUser?> GetUserAsync(string userName, CancellationToken cancellationToken = default);
}
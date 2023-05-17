using AuthApp.Application.Interfaces;
using AuthApp.Core.Entities;
using AuthApp.Core.Repositories;

namespace AuthApp.Application.Services;

internal class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHashingService _passwordHashingService;

    public UserService(IUserRepository userRepository, IPasswordHashingService passwordHashingService)
    {
        _userRepository = userRepository;
        _passwordHashingService = passwordHashingService;
    }

    public async Task<ApplicationUser?> FindByUserNameAsync(string userName,
        CancellationToken cancellationToken = default)
    {
        return await _userRepository.FindByUserNameAsync(userName, cancellationToken);
    }
}
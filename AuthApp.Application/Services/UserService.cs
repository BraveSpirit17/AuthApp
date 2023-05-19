using AuthApp.Application.Dto;
using AuthApp.Application.Interfaces;
using AuthApp.Core.Entities;
using AuthApp.Core.Repositories;
using AutoMapper;

namespace AuthApp.Application.Services;

internal class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHashingService _passwordHashingService;

    public UserService(IUserRepository userRepository, IPasswordHashingService passwordHashingService, IMapper mapper)
    {
        _userRepository = userRepository;
        _passwordHashingService = passwordHashingService;
        _mapper = mapper;
    }

    public async Task<ApplicationUser?> FindByUserNameAsync(string userName,
        CancellationToken cancellationToken = default)
    {
        return await _userRepository.FindByUserNameAsync(userName, cancellationToken);
    }

    public async Task<UserDto> CreateUserAsync(ApplicationUser user, string password)
    {
        //TODO
        //return Email already in use
        // var existingUser = await _userRepository.FindByEmailAsync(user.Email);
        // if (existingUser != null)
        // {
        //     
        // }

        user.PasswordHash = _passwordHashingService.GetHash(password);

        await _userRepository.AddAsync(user);

        return _mapper.Map<UserDto>(user);
    }
}
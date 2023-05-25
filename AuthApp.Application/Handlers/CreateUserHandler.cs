using AuthApp.Application.Commands;
using AuthApp.Application.Dto;
using AuthApp.Application.Interfaces;
using AuthApp.Core.Entities;
using AutoMapper;
using MediatR;

namespace AuthApp.Application.Handlers;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, UserDto>
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    private readonly IPasswordHashingService _passwordHashingService;

    public CreateUserHandler(IUserService userService, IMapper mapper, IPasswordHashingService passwordHashingService)
    {
        _userService = userService;
        _mapper = mapper;
        _passwordHashingService = passwordHashingService;
    }

    public Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<ApplicationUser>(request);

        user.PasswordHash = _passwordHashingService.GetHash(request.Password);
        
        return _userService.CreateUserAsync(user);
    }
}
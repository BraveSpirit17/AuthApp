using AuthApp.Application.Commands;
using AuthApp.Application.Dto;
using AuthApp.Application.Interfaces;
using AuthApp.Core.Entities;
using AutoMapper;
using MediatR;

namespace AuthApp.Application.Handlers;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, TokenDto>
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    private readonly IPasswordHashingService _passwordHashingService;
    private readonly IAuthenticationService _authenticationService;

    public CreateUserHandler(IUserService userService, IMapper mapper, IPasswordHashingService passwordHashingService,
        IAuthenticationService authenticationService)
    {
        _userService = userService;
        _mapper = mapper;
        _passwordHashingService = passwordHashingService;
        _authenticationService = authenticationService;
    }

    public async Task<TokenDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<ApplicationUser>(request);

        user.PasswordHash = _passwordHashingService.GetHash(request.Password);

        var userDto = await _userService.CreateUserAsync(user);

        return await _authenticationService.CreateAccessTokenAsync(userDto.UserName, request.Password);
    }
}
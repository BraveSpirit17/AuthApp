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

    public CreateUserHandler(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    public Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<ApplicationUser>(request);
        
        return _userService.CreateUserAsync(user, request.Password);
    }
}
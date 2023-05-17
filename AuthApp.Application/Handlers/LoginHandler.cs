using AuthApp.Application.Commands;
using AuthApp.Application.Dto;
using AuthApp.Application.Interfaces;
using MediatR;

namespace AuthApp.Application.Handlers;

public class LoginHandler : IRequestHandler<LoginCommand, TokenDto>
{
    private readonly IAuthenticationService _authenticationService;

    public LoginHandler(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    public async Task<TokenDto> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        return await _authenticationService.CreateAccessTokenAsync(request.UserName, request.Password);
    }
}
using AuthApp.Application.Dto;
using AuthApp.Application.Interfaces;
using AuthApp.Application.Queries;
using MediatR;

namespace AuthApp.Application.Handlers;

public class LoginHandler : IRequestHandler<LoginQuery, TokenDto>
{
    private readonly IAuthenticationService _authenticationService;

    public LoginHandler(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    public async Task<TokenDto> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        return await _authenticationService.CreateAccessTokenAsync(request.UserName, request.Password);
    }
}
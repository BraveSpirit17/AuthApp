using AuthApp.Application.Commands;
using AuthApp.Application.Dto;
using MediatR;

namespace AuthApp.Application.Handlers;

public class LoginHandler : IRequestHandler<LoginCommand, AccessTokenDto>
{
    public Task<AccessTokenDto> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
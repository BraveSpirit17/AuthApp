using AuthApp.Application.Dto;
using MediatR;

namespace AuthApp.Application.Commands;

public record LoginCommand(string UserName, string Password, string Email) : IRequest<AccessTokenDto>;
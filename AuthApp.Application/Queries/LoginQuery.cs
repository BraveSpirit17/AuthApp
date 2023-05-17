using AuthApp.Application.Dto;
using MediatR;

namespace AuthApp.Application.Queries;

public record LoginQuery(string UserName, string Password, string Email) : IRequest<TokenDto>;
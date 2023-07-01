using AuthApp.Application.Dto;
using MediatR;

namespace AuthApp.Application.Commands;

public class CreateUserCommand : IRequest<TokenDto>
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string? MiddleName { get; set; }

    public string UserName { get; set; }

    public string Password { get; set; }

    public string Email { get; set; }
}
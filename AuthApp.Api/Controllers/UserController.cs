using AuthApp.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AuthApp.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand userCommand)
    {
        return Ok(await _mediator.Send(userCommand));
    }
}
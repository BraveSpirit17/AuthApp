using AuthApp.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthApp.Api.Controllers;

[Route("api/user")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet, Authorize]
    public async Task<IActionResult> Test()
    {
        return Ok("Test");
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserCommand userCommand)
    {
        return Ok(await _mediator.Send(userCommand));
    }
}
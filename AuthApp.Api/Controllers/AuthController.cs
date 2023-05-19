using AuthApp.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AuthApp.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromBody] LoginQuery loginQuery)
    {
        return Ok(await _mediator.Send(loginQuery));
    }

    // [HttpPost]
    // public async Task<IActionResult> GetToken(UserCredentialDto userDto)
    // {
    //     return Ok(_tokenService.TokenGeneration(userDto.UserName));
    // }
}
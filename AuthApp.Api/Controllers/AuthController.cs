using AuthApp.Application.Commands;
using AuthApp.Application.Dto;
using AuthApp.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AuthApp.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ITokenService _tokenService;

    public AuthController(ITokenService tokenService, IMediator mediator)
    {
        _tokenService = tokenService;
        _mediator = mediator;
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromBody] UserCredentialDto userCredential)
    {
        return Ok(await _mediator.Send(new LoginCommand(userCredential.UserName,
            userCredential.Password, userCredential.Password)));
    }

    // [HttpPost]
    // public async Task<IActionResult> GetToken(UserCredentialDto userDto)
    // {
    //     return Ok(_tokenService.TokenGeneration(userDto.UserName));
    // }
}
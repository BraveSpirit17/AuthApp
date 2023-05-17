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
        // var response = await _authenticationService
        //     .CreateAccessTokenAsync(userCredentials.Email, userCredentials.Password);
        //
        // if (!response.Success)
        // {
        //     return BadRequest(response.Message);
        // }
        //
        // var accessTokenResource = _mapper.Map<AccessToken, AccessTokenResource>(response.Token);
        //
        // return Ok(accessTokenResource);
        //return await _mediator.Send(new GetEmployeeByIdQuery(id));
        return Ok();
    }

    // [HttpPost]
    // public async Task<IActionResult> GetToken(UserCredentialDto userDto)
    // {
    //     return Ok(_tokenService.TokenGeneration(userDto.UserName));
    // }
}
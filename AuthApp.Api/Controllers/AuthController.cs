using AuthApp.Application.Dto;
using AuthApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AuthApp.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly ITokenService _tokenService;

    public AuthController(ITokenService tokenService)
    {
        _tokenService = tokenService;
    }

    [HttpPost]
    public async Task<IActionResult> GetToken(ApplicationUserDto applicationUserDto)
    {
        return Ok(_tokenService.TokenGeneration(applicationUserDto.UserName));
    }
}
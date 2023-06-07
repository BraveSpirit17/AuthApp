using AuthApp.Api.Controllers.Base;
using AuthApp.Application.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthApp.Api.Controllers;

public class UserController : ApiController
{
    [HttpGet, Authorize]
    public async Task<IActionResult> Test()
    {
        return Ok("Test");
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserCommand userCommand)
    {
        return Ok(await Mediator.Send(userCommand));
    }
}
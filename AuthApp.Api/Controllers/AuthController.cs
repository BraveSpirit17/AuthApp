using AuthApp.Api.Controllers.Base;
using AuthApp.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace AuthApp.Api.Controllers;

public class AuthController : ApiController
{
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginQuery loginQuery)
    {
        return Ok(await Mediator.Send(loginQuery));
    }
}
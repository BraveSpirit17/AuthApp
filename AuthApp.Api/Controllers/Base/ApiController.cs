using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AuthApp.Api.Controllers.Base;

[ApiController]
[Route("api/[controller]/[action]")]
public abstract class ApiController : ControllerBase
{
    protected IMediator Mediator => this.HttpContext.RequestServices.GetService<IMediator>();
}
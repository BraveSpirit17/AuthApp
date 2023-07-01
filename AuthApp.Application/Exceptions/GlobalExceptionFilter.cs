using System.Net;
using System.Security.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AuthApp.Application.Exceptions;

public class GlobalExceptionFilter : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        switch (context.Exception)
        {
            case WebException:
                context.HttpContext.Response.StatusCode = (int)WebExceptionStatus.UnknownError;
                break;

            case ArgumentException:
                context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                break;

            case AuthenticationException:
                context.HttpContext.Response.StatusCode = StatusCodes.Status423Locked;
                break;
            
            default:
                context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                break;
        }

        var apiError = new ApiError
        {
            Message = context.Exception.Message,
            Code = context.HttpContext.Response.StatusCode
        };

        context.Result = new JsonResult(apiError);
        base.OnException(context);
    }
}
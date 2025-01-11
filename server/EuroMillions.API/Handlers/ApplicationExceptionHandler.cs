namespace EuroMillions.API.Handlers;

using System.Net;

using Microsoft.AspNetCore.Diagnostics;

public class ApplicationExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is not ApplicationException)
        {
            return false;
        }

        httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        httpContext.Response.ContentType = "application/json";

        await httpContext.Response.WriteAsJsonAsync(new { StatusCode = httpContext.Response.StatusCode, Message = exception.Message });

        return true;
    }
}

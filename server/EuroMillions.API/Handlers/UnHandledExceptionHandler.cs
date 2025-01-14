namespace EuroMillions.API.Handlers;

using System.Net;

using Microsoft.AspNetCore.Diagnostics;

public class UnHandledExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        httpContext.Response.ContentType = "application/json";

        await httpContext.Response.WriteAsJsonAsync(new {StatusCode = httpContext.Response.StatusCode, Message = exception.Message},
            cancellationToken: cancellationToken);

        return true;
    }
}

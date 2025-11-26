using System.Net;

using Microsoft.AspNetCore.Diagnostics;

namespace EuroMillions.API.Handlers;

public class UnHandledExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken
    )
    {
        httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        httpContext.Response.ContentType = "application/json";

        await httpContext.Response.WriteAsJsonAsync(
            new {httpContext.Response.StatusCode, exception.Message},
            cancellationToken
        );

        return true;
    }
}

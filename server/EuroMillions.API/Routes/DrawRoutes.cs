using EuroMillions.API.Resources;

using Microsoft.AspNetCore.Mvc;

namespace EuroMillions.API.Routes;

public static class DrawRoutes
{
    public static void UseDrawRoutes(this IEndpointRouteBuilder app)
    {
        RouteGroupBuilder drawsGroup = app.MapGroup("/draws");

        drawsGroup.DisableAntiforgery();

        drawsGroup.MapGet(
            "/getlastdraw",
            async ([FromServices] DrawResources drawResources) => await drawResources.GetLastDrawAsync()
        );

        drawsGroup.MapPost(
            "/history_files",
            async ([FromServices] DrawResources drawResources, [FromForm] IFormFileCollection files) =>
            await drawResources.UploadFilesAsync(files)
        );
    }
}

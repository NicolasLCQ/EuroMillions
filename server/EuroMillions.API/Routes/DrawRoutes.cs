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

        drawsGroup.MapGet(
            "/nextdraw",
            async ([FromServices] DrawResources drawResources) => await drawResources.GetNextDrawAsync()
        );

        drawsGroup.MapGet(
            "/areuptodate",
            async ([FromServices] DrawResources drawResources) => await drawResources.AreDrawsUpToDateAsync()
        );

        drawsGroup.MapGet(
            "/updateautomatically",
            async ([FromServices] DrawResources drawResources) =>
            await drawResources.UpdateAutomaticallyAsync()
        );

        drawsGroup.MapPost(
            "/upload",
            async ([FromServices] DrawResources drawResources, [FromForm] IFormFileCollection files) =>
            await drawResources.UploadFilesAsync(files)
        );
    }
}

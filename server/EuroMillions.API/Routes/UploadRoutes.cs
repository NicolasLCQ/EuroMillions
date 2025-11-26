using EuroMillions.API.Resources;

using Microsoft.AspNetCore.Mvc;

namespace EuroMillions.API.Routes;

public static class UploadRoutes
{
    public static void UseUploadRoutes(this IEndpointRouteBuilder app)
    {
        RouteGroupBuilder uploadGroup = app.MapGroup("/upload");

        uploadGroup.DisableAntiforgery();

        uploadGroup.MapPost(
            "/history_files",
            async ([FromServices] UploadRessource uploadRessource, [FromForm] IFormFileCollection files) =>
            await uploadRessource.UploadFilesAsync(files)
        );
    }
}

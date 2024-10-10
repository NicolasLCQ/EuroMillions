namespace EuroMillions.API.Routes;

using Microsoft.AspNetCore.Mvc;

using Resources;

public static class UploadRoutes
{
    public static void UseUploadRoutes(this IEndpointRouteBuilder app)
    {
        RouteGroupBuilder? uploadGroup = app
            .MapGroup("/upload")
            .DisableAntiforgery();

        uploadGroup.MapPost("/history_files", ([FromServices] UploadRessource manager, [FromForm] IFormFileCollection files) => manager.UplaodFilesAsync(files));
    }
}

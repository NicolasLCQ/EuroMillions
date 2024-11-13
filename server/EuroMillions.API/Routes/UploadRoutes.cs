namespace EuroMillions.API.Routes;

using Microsoft.AspNetCore.Mvc;

using Resources;

public static class UploadRoutes
{
    public static void UseUploadRoutes(this IEndpointRouteBuilder app)
    {
        RouteGroupBuilder? uploadGroup = app.MapGroup("/upload");
        uploadGroup.DisableAntiforgery();
        uploadGroup.MapPost("/history_files", ([FromServices] UploadRessource uploadRessource, [FromForm] IFormFileCollection files) => uploadRessource.UplaodFilesAsync(files));
    }
}

namespace EuroMillions.API.Routes;

using Microsoft.AspNetCore.Mvc;

using Resources;

public static class UploadRoutes
{
    public static void UseUploadRoutes(this IEndpointRouteBuilder app)
    {
        RouteGroupBuilder uploadGroup = app.MapGroup("/upload");

        uploadGroup.MapPost("/history_files/post",//body temp
            ([FromServices] UploadRessource manager, [FromBody] List<List<byte>> files) => manager.NotImplementedYet());
    }
}

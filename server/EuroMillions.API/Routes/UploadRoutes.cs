namespace EuroMillions.API.Routes;

public static class UploadRoutes
{
    public static void UseUploadRoutes(this IEndpointRouteBuilder app)
    {
        RouteGroupBuilder uploadGroup = app.MapGroup("/upload");

        uploadGroup.MapPost("/history_files/post", NotImplementedYet);
    }

    private static async Task<IResult> NotImplementedYet() => TypedResults.Ok("Not Implemented Yet");
}

namespace EuroMillions.API.Routes;

public static class UploadRoutes
{
    public static void UseUploadRoutes(this IEndpointRouteBuilder app)
    {
        RouteGroupBuilder uploadGroup = app.MapGroup("/upload");

        uploadGroup.MapPost("/history_files/post", NotImplementedYet);
    }

    static async Task<IResult> NotImplementedYet()
    {
        return TypedResults.Ok("Not Implemented Yet");
    }
}
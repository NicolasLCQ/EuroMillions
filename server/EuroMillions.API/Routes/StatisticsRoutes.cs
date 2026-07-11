namespace EuroMillions.API.Routes;

public static class StatisticsRoutes
{
    public static void UseStatisticsRoutes(this IEndpointRouteBuilder app)
    {
        RouteGroupBuilder statisticsGroup = app.MapGroup("/statistics");
    }
}

using EuroMillions.API.Resources;

using Microsoft.AspNetCore.Mvc;

namespace EuroMillions.API.Routes;

public static class StatisticsRoutes
{
    public static void UseStatisticsRoutes(this IEndpointRouteBuilder app)
    {
        RouteGroupBuilder statisticsGroup = app.MapGroup("/statistics");
        RouteGroupBuilder numbersStatisticsGroup = statisticsGroup.MapGroup("/numbers");
        RouteGroupBuilder starsStatisticsGroup = statisticsGroup.MapGroup("/stars");

        numbersStatisticsGroup.MapGet(
            "/NbTimePicked",
            async ([FromServices] StatisticsResources statisticsResources) =>
            await statisticsResources.GetAllBallsNbTimePickedAsync()
        );

        starsStatisticsGroup.MapGet(
            "/NbTimePicked",
            async ([FromServices] StatisticsResources statisticsResources) =>
            await statisticsResources.GetAllStarsNbTimePickedAsync()
        );
    }
}

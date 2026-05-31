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

        numbersStatisticsGroup.MapGet(
            "/{ballNumber:int}/NbTimePicked",
            async ([FromServices] StatisticsResources statisticsResources, [FromRoute] int ballNumber) =>
            await statisticsResources.GetBallNbTimePickedAsync(ballNumber)
        );

        starsStatisticsGroup.MapGet(
            "/NbTimePicked",
            async ([FromServices] StatisticsResources statisticsResources) =>
            await statisticsResources.GetAllStarsNbTimePickedAsync()
        );

        starsStatisticsGroup.MapGet(
            "/{starNumber:int}/NbTimePicked",
            async ([FromServices] StatisticsResources statisticsResources, [FromRoute] int starNumber) =>
            await statisticsResources.GetStarNbTimePickedAsync(starNumber)
        );
    }
}

using EuroMillions.API.Resources;

using Microsoft.AspNetCore.Mvc;

namespace EuroMillions.API.Routes;

public static class StatisticsRoutes
{
    public static void UseStatisticsRoutes(this IEndpointRouteBuilder app)
    {
        RouteGroupBuilder statisticsGroup = app.MapGroup("/statistics");

        statisticsGroup.MapGet(
            "",
            async ([FromServices] StatisticsResources statisticsResources) =>
            await statisticsResources.GetStatisticsAsync()
        );
    }
}

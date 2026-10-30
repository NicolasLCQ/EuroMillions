using EuroMillions.API.Mappers;
using EuroMillions.API.ViewModels;
using EuroMillions.Application.Interfaces.UseCases;

namespace EuroMillions.API.Resources;

public class StatisticsResources(IDrawUseCases drawUseCases)
{
    public async Task<IResult> GetStatisticsAsync()
    {
        GetStatisticsResponseViewModel response = (await drawUseCases.GetStatisticsAsync())
            .ToStatisticsResponseViewModel();

        return Results.Ok(response);
    }
}

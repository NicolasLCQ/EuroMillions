using EuroMillions.API.ViewModels;
using EuroMillions.Application.Models;

namespace EuroMillions.API.Mappers;

public static class GetStatisticsReponseViewModelMapper
{
    public static GetStatisticsResponseViewModel ToStatisticsResponseViewModel(this DrawItemsStatisticsModel drawItemsStatistics) =>
        new GetStatisticsResponseViewModel
        {
            Stars = drawItemsStatistics.Stars.Select(s => s.ToStatisticViewModel()).ToList(),
            Balls = drawItemsStatistics.Balls.Select(b => b.ToStatisticViewModel()).ToList()
        };
}

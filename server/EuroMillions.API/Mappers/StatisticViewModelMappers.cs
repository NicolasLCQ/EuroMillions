using EuroMillions.API.ViewModels;
using EuroMillions.Application.Models;

namespace EuroMillions.API.Mappers;

public static class StatisticViewModelMappers
{
    public static BallStatisticsViewModel ToStatisticsResponseViewModel(this DrawItemStatisticsModel<Ball> statistics)
        => new BallStatisticsViewModel {Ball = statistics.DrawItem, NbTimesDraw = statistics.NbTimesDraw};

    public static StarStatisticsViewModel ToStatisticsResponseViewModel(this DrawItemStatisticsModel<Star> statistics)
        => new StarStatisticsViewModel {Star = statistics.DrawItem, NbTimesDraw = statistics.NbTimesDraw};

    public static GetStatisticsResponseViewModel ToStatisticsResponseViewModel(this DrawItemsStatisticsModel statistics)
        => new GetStatisticsResponseViewModel
        {
            Balls = statistics.Balls.Select(b => b.ToStatisticsResponseViewModel()).ToList(),
            Stars = statistics.Stars.Select(s => s.ToStatisticsResponseViewModel()).ToList()
        };
}

using EuroMillions.API.ViewModels;
using EuroMillions.Application.Models;

namespace EuroMillions.API.Mappers;

public static class StatisticViewModelMappers
{
    public static BallStatisticsViewModel ToStatisticsResponseViewModel(this BallStatisticsModel statistics)
        => new BallStatisticsViewModel
        {
            Ball = statistics.Ball,
            NbTimesDraw = statistics.NbTimesDraw,
            NbDrawsSinceLastOccurrence = statistics.NbDrawsSinceLastOccurrence,
            AverageNbDrawsBetweenOccurrences = statistics.AverageNbDrawsBetweenOccurrences
        };

    public static StarStatisticsViewModel ToStatisticsResponseViewModel(this StarStatisticsModel statistics)
        => new StarStatisticsViewModel
        {
            Star = statistics.Star,
            NbTimesDraw = statistics.NbTimesDraw,
            NbDrawsSinceLastOccurrence = statistics.NbDrawsSinceLastOccurrence,
            AverageNbDrawsBetweenOccurrences = statistics.AverageNbDrawsBetweenOccurrences
        };

    public static GetStatisticsResponseViewModel ToStatisticsResponseViewModel(this DrawItemsStatisticsModel statistics)
        => new GetStatisticsResponseViewModel
        {
            Balls = statistics.Balls.Select(b => b.ToStatisticsResponseViewModel()).ToList(),
            Stars = statistics.Stars.Select(s => s.ToStatisticsResponseViewModel()).ToList()
        };
}

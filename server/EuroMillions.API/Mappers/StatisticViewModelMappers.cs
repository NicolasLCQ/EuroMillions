using EuroMillions.API.ViewModels;
using EuroMillions.Application.Models;

namespace EuroMillions.API.Mappers;

public static class StatisticViewModelMappers
{
    public static StatisticViewModel ToStatisticViewModel(this DrawItemStatisticsModel statistics) =>
        new StatisticViewModel
        {
            DrawItem = statistics.GetDrawItem(),
            NbTimesDraw = statistics.NbTimesDraw
        };
}

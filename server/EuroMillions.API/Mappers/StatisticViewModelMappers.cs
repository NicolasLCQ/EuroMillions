using EuroMillions.API.ViewModels;
using EuroMillions.Application.Models;

namespace EuroMillions.API.Mappers;

public static class StatisticViewModelMappers
{
    public static StatisticViewModel ToStatisticViewModel(this DrawItemStatisticsModel<DrawItemAbstraction> statistics) =>
        new StatisticViewModel {DrawItem = statistics.DrawItem, NbTimesDraw = statistics.NbTimesDraw};
}

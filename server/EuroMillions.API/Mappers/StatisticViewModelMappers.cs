using EuroMillions.API.ViewModels;
using EuroMillions.Application.Models;

namespace EuroMillions.API.Mappers;

public static class StatisticViewModelMappers
{
    public static StatisticViewModel ToStatisticViewModel<TDrawItem>(this DrawItemStatisticsModel<TDrawItem> statistics)
        where TDrawItem : DrawItemAbstraction =>
        new StatisticViewModel {DrawItem = statistics.DrawItem, NbTimesDraw = statistics.NbTimesDraw};
}

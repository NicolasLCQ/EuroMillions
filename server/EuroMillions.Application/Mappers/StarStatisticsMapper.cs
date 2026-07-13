using EuroMillions.Application.Models;

namespace EuroMillions.Application.Mappers;

public static class StarStatisticsMapper
{
    public static StarStatisticsModel ToStarStatisticsModel(this KeyValuePair<Star, int> entry) =>
        new StarStatisticsModel
        {
            Star = entry.Key,
            NbTimesDraw = entry.Value
        };
}

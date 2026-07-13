using EuroMillions.Application.Models;

namespace EuroMillions.Application.Mappers;

public static class StarStatisticsMapper
{
    public static DrawItemStatisticsModel<Star> ToStarStatisticsModel(this KeyValuePair<Star, int> entry) =>
        entry.ToDrawItemStatisticsModel();
}

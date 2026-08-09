using EuroMillions.Application.Models;

namespace EuroMillions.Application.Mappers;

public static class DrawItemStatisticsMapper
{
    public static BallStatisticsModel ToBallStatisticsModel(this KeyValuePair<Ball, int> entry, int nbDrawsSinceLastOccurrence)
        =>
            new BallStatisticsModel
            {
                Ball = entry.Key,
                NbTimesDraw = entry.Value,
                NbDrawsSinceLastOccurrence = nbDrawsSinceLastOccurrence
            };

    public static StarStatisticsModel ToStarStatisticsModel(this KeyValuePair<Star, int> entry, int nbDrawsSinceLastOccurrence)
        =>
            new StarStatisticsModel
            {
                Star = entry.Key,
                NbTimesDraw = entry.Value,
                NbDrawsSinceLastOccurrence = nbDrawsSinceLastOccurrence
            };
}

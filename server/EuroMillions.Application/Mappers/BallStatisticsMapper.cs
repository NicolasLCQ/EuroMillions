using EuroMillions.Application.Models;

namespace EuroMillions.Application.Mappers;

public static class BallStatisticsMapper
{
    public static BallStatisticsModel ToBallStatisticsModel(this KeyValuePair<Ball, int> entry) =>
        new BallStatisticsModel
        {
            Ball = entry.Key,
            NbTimesDraw = entry.Value
        };

}

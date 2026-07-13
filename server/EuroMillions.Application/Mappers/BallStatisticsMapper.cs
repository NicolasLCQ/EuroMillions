using EuroMillions.Application.Models;

namespace EuroMillions.Application.Mappers;

public static class BallStatisticsMapper
{
    public static DrawItemStatisticsModel<Ball> ToBallStatisticsModel(this KeyValuePair<Ball, int> entry) =>
        entry.ToDrawItemStatisticsModel();
}

namespace EuroMillions.Application.Models;

public class DrawItemsStatisticsModel
{
    public required List<StarStatisticsModel> Stars { get; set; }
    public required List<BallStatisticsModel> Balls { get; set; }
}

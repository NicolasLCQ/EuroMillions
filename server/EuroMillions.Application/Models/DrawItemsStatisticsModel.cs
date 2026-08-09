namespace EuroMillions.Application.Models;

public class DrawItemsStatisticsModel
{
    public List<StarStatisticsModel> Stars { get; set; } = [];
    public List<BallStatisticsModel> Balls { get; set; } = [];
}

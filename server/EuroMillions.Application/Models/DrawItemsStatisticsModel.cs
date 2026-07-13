namespace EuroMillions.Application.Models;

public class DrawItemsStatisticsModel
{
    public List<DrawItemStatisticsModel<Star>> Stars { get; set; } = [];
    public List<DrawItemStatisticsModel<Ball>> Balls { get; set; } = [];
}

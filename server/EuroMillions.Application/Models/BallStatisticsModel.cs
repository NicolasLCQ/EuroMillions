namespace EuroMillions.Application.Models;

public class BallStatisticsModel : DrawItemStatisticsModel
{
    public required Ball Ball { get; set; }
    public override int GetDrawItem() => Ball;
}

namespace EuroMillions.Application.Models;

public class StarStatisticsModel : DrawItemStatisticsModel
{
    public required Star Star { get; set; }
    public override int GetDrawItem() => Star;
}

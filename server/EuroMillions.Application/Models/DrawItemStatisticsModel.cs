namespace EuroMillions.Application.Models;

public class DrawItemStatisticsModel
{
    public required int NbTimesDraw { get; set; }
    public required int NbDrawsSinceLastOccurrence { get; set; }
}

namespace EuroMillions.API.ViewModels;

public class DrawItemStatisticsViewModel
{
    public required int NbTimesDraw { get; set; }
    public required int NbDrawsSinceLastOccurrence { get; set; }
}

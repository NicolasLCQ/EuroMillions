namespace EuroMillions.API.ViewModels;

public class DrawItemStatisticsViewModel
{
    public required int NbTimesDraw { get; set; }
    public required int NbDrawsSinceLastOccurrence { get; set; }
    public required double AverageNbDrawsBetweenOccurrences { get; set; }
    public required int MinimumNbDrawsBetweenOccurrences { get; set; }
    public required int MaximumNbDrawsBetweenOccurrences { get; set; }
    public required double VarianceNbDrawsBetweenOccurrences { get; set; }
}

namespace EuroMillions.Application.Models;

public class DrawItemStatisticsModel<TDrawItem>
    where TDrawItem : DrawItemAbstraction
{
    public required TDrawItem DrawItem { get; set; }
    public int NbTimesDraw { get; set; }
    public int NbDrawsSinceLastOccurrence { get; set; }
}

namespace EuroMillions.Application.Models;

public class DrawItemStatisticsModel<TDrawItem>
{
    public required TDrawItem DrawItem { get; set; }
    public int NbTimesDraw { get; set; }
}

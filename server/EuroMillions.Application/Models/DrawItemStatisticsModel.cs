namespace EuroMillions.Application.Models;

public abstract class DrawItemStatisticsModel
{
    public abstract int GetDrawItem();
    public int NbTimesDraw { get; set; }
}

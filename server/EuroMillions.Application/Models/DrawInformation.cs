namespace EuroMillions.Application.Models;

public class DrawInformation : IHasDrawDate
{
    public int YearDrawNumber { get; set; }
    public DateTime DrawDate { get; set; }
    public string? DrawDay { get; set; }
    public DateTime? ForclusionDate { get; set; }
    public int? DrawNumberInCycle { get; set; }
}

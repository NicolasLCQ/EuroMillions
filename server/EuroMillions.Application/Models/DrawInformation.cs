namespace EuroMillions.Application.Models;

public class DrawInformation
{
    public required int YearDrawNumber { get; set; }
    public required DateTime DrawDate { get; set; }
    public required string DrawDay { get; set; }
    public required DateTime ForclusionDate { get; set; }
    public required int DrawNumberInCycle { get; set; }
}

namespace EuroMillions.Application.Models;

public class DrawSummaryModel
{
    public required int DrawNumber { get; set; }
    public required DateTime DrawDate { get; set; }
    public required Ball Ball1 { get; set; }
    public required Ball Ball2 { get; set; }
    public required Ball Ball3 { get; set; }
    public required Ball Ball4 { get; set; }
    public required Ball Ball5 { get; set; }
    public required Star Star1 { get; set; }
    public required Star Star2 { get; set; }
    public required string? JokerPlusNumber { get; set; }
    public required string? MyMillionNumber { get; set; }
    public required string? ExceptionalEuroMillionsDrawNumber { get; set; }
    public required DrawWinners Winners { get; set; }
}

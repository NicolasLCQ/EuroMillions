namespace EuroMillions.Application.Models;

public class Draw
{
    public required Ball Star1 { get; set; }
    public required Ball Star2 { get; set; }
    public required Ball Ball1 { get; set; }
    public required Ball Ball2 { get; set; }
    public required Ball Ball3 { get; set; }
    public required Ball Ball4 { get; set; }
    public required Ball Ball5 { get; set; }

    public int YearDrawNumber { get; set; }
    public DateTime DrawDate { get; set; }
}

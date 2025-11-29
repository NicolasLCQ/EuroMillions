namespace EuroMillions.Application.Models;

public class Draw
{
    public required Ball Ball1;
    public required Ball Ball2;
    public required Ball Ball3;
    public required Ball Ball4;
    public required Ball Ball5;

    public required Ball Star1;
    public required Ball Star2;

    public int YearDrawNumber { get; set; }
    public DateTime DrawDate { get; set; }
}

namespace EuroMillions.Application.Models;

public class Draw
{
    public required Star Star1 { get; set; }
    public required Star Star2 { get; set; }
    public required Ball Ball1 { get; set; }
    public required Ball Ball2 { get; set; }
    public required Ball Ball3 { get; set; }
    public required Ball Ball4 { get; set; }
    public required Ball Ball5 { get; set; }

    public string? WinningBallsInAscendingOrder { get; set; }
    public string? WinningStarsInAscendingOrder { get; set; }
    public DrawWinners? Winners { get; set; }
    public DrawInformation? DrawInformation { get; set; }
    public DrawAdditionalGame? AdditionalGame { get; set; }
}

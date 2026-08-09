namespace EuroMillions.API.ViewModels;

public class DrawPrizeRankResponseViewModel
{
    public required int Rank { get; set; }
    public required int WinnersFrance { get; set; }
    public required int WinnersEurope { get; set; }
    public required decimal Prize { get; set; }
}

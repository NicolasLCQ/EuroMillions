namespace EuroMillions.API.ViewModels;

public class DrawPrizeRankResponseViewModel
{
    public int Rank { get; set; }
    public int WinnersFrance { get; set; }
    public int WinnersEurope { get; set; }
    public decimal Prize { get; set; }
}

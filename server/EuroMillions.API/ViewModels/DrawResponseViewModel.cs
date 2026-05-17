namespace EuroMillions.API.ViewModels;

public class DrawResponseViewModel
{
    public int DrawNumber { get; set; }
    public DateTime DrawDate { get; set; }
    public int Ball1 { get; set; }
    public int Ball2 { get; set; }
    public int Ball3 { get; set; }
    public int Ball4 { get; set; }
    public int Ball5 { get; set; }
    public int Star1 { get; set; }
    public int Star2 { get; set; }
    public string? JokerPlusNumber { get; set; }
    public string? MyMillionNumber { get; set; }
    public string? ExceptionalEuroMillionsDrawNumber { get; set; }
    public List<DrawPrizeRankResponseViewModel> EuroMillionsPrizeRanks { get; set; } = [];
}

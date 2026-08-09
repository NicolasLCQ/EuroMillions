namespace EuroMillions.API.ViewModels;

public class DrawResponseViewModel
{
    public required int DrawNumber { get; set; }
    public required DateTime DrawDate { get; set; }
    public required int Ball1 { get; set; }
    public required int Ball2 { get; set; }
    public required int Ball3 { get; set; }
    public required int Ball4 { get; set; }
    public required int Ball5 { get; set; }
    public required int Star1 { get; set; }
    public required int Star2 { get; set; }
    public required string? JokerPlusNumber { get; set; }
    public required string? MyMillionNumber { get; set; }
    public required string? ExceptionalEuroMillionsDrawNumber { get; set; }
    public required List<DrawPrizeRankResponseViewModel> EuroMillionsPrizeRanks { get; set; }
}

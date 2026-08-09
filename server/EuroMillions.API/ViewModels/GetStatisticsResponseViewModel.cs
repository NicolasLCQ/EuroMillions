namespace EuroMillions.API.ViewModels;

public class GetStatisticsResponseViewModel
{
    public required List<StarStatisticsViewModel> Stars { get; set; }
    public required List<BallStatisticsViewModel> Balls { get; set; }
}

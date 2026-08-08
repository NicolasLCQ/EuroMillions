namespace EuroMillions.API.ViewModels;

public class GetStatisticsResponseViewModel
{
    public List<StarStatisticsViewModel> Stars { get; set; } = [];
    public List<BallStatisticsViewModel> Balls { get; set; } = [];
}

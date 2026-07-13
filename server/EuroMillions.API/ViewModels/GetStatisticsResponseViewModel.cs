namespace EuroMillions.API.ViewModels;

public class GetStatisticsResponseViewModel
{
    public List<StatisticViewModel> Stars { get; set; } = [];
    public List<StatisticViewModel> Balls { get; set; } = [];
}

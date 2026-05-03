namespace EuroMillions.API.ViewModels;

public class UploadFileResponseViewModel
{
    public required string FileName { get; set; }
    public List<DrawResponseViewModel> AcceptedDraws { get; set; } = [];
    public List<RejectedDrawResponseViewModel> RejectedDraws { get; set; } = [];
}

namespace EuroMillions.API.ViewModels;

public class UploadFileResponseViewModel
{
    public required string FileName { get; set; }
    public required List<DrawResponseViewModel> AcceptedDraws { get; set; }
    public required List<RejectedDrawResponseViewModel> RejectedDraws { get; set; }
}

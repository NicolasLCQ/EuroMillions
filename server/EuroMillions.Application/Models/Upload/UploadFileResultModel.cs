namespace EuroMillions.Application.Models.Upload;

public class UploadFileResultModel
{
    public string FileName { get; set; }
    public List<Draw> AcceptedDraws { get; set; } = [];
    public List<RejectedDraw> RejectedDraws { get; set; } = [];
}

namespace EuroMillions.Application.Models.Upload;

public class UploadFileResultModel
{
    public required string FileName { get; set; }
    public required List<Draw> AcceptedDraws { get; set; }
    public required List<RejectedDraw> RejectedDraws { get; set; }
}

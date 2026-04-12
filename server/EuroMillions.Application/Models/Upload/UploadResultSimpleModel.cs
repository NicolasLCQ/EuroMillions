namespace EuroMillions.Application.Models.Upload;

public class UploadResultSimpleModel
{
    public string FileName { get; set; }
    public List<Draw> AcceptedDraws { get; set; }
    public List<Draw> RejectedDraws { get; set; }
}

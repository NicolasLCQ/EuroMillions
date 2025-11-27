namespace EuroMillions.Application.Models.Upload;

public class UploadResultModel
{
    //TODO: change : nbFilesAdded, fileOfRejected?{fileName,drawId,Reason}
    public string FileName { get; set; }
    public List<Draw> AcceptedDraws { get; set; }
    public List<Draw> RejectedDraws { get; set; }
}

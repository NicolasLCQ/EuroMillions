namespace EuroMillions.Application.Models.Upload;

public class UploadFileModel
{
    public required string FileName { get; init; }
    public required Stream Content { get; init; }
}

namespace EuroMillions.Application.Models.Upload;

public class DrawFileModel
{
    public required string FileName { get; set; }
    public required List<Draw> Draws { get; set; }
}

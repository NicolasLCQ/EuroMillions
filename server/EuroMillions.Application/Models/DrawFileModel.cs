namespace EuroMillions.Data.Models;

using Application.Models;

public class DrawFileModel
{
    public string FileName { get; set; }
    public List<Draw> Draws { get; set; }
}

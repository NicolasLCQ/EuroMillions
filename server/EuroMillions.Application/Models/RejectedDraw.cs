namespace EuroMillions.Application.Models.Upload;

public class RejectedDraw : Draw
{
    public required string Reason { get; set; }
}

namespace EuroMillions.API.ViewModels;

public class RejectedDrawResponseViewModel : DrawResponseViewModel
{
    public required string Reason { get; set; }
}

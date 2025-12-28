namespace EuroMillions.API.Models.ResponseModels;

public class GetLastDrawResponseModel
{
    public bool isUpToDate { get; set; }
    public DrawReponseModel Draw { get; set; }
}

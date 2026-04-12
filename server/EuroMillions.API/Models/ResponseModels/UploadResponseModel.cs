namespace EuroMillions.API.Models.ResponseModels;

public class UploadResponseModel
{
    private List<DrawReponseModel> AcceptedDraws { get; set; }
    private List<RejectedDrawResponseModel> RejectedDraws { get; set; }
}

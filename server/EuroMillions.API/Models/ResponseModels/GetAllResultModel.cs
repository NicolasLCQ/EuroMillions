namespace EuroMillions.API.Models.ResponseModels;

public class GetAllResultModel
{
    public required List<DrawReponseModel> Draws { get; set; }
}

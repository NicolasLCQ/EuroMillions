namespace EuroMillions.API.Models.ResponseModels;

public class DrawReponseModel
{
    public int DrawNumber { get; set; }
    public DateTime DrawDate { get; set; }
    public int Ball1 { get; set; }
    public int Ball2 { get; set; }
    public int Ball3 { get; set; }
    public int Ball4 { get; set; }
    public int Ball5 { get; set; }
    public int Star1 { get; set; }
    public int Star2 { get; set; }
}

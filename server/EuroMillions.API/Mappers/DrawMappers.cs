using EuroMillions.API.Models.ResponseModels;
using EuroMillions.Application.Models;

namespace EuroMillions.API.Mappers;

public static class DrawMappers
{
    public static DrawReponseModel ToDrawResponseModel(this Draw draw) =>
        new DrawReponseModel
        {
            DrawNumber = draw.YearDrawNumber,
            DrawDate = draw.DrawDate,
            Ball1 = draw.Ball1,
            Ball2 = draw.Ball2,
            Ball3 = draw.Ball3,
            Ball4 = draw.Ball4,
            Ball5 = draw.Ball5,
            Star1 = draw.Star1,
            Star2 = draw.Star2
        };

    public static GetLastDrawResponseModel ToGetLastDrawResponseModel(this Draw draw) =>
        new GetLastDrawResponseModel {isUpToDate = true, Draw = draw.ToDrawResponseModel()};
}

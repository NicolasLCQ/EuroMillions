using EuroMillions.Application.Models;
using EuroMillions.Infrastructure.Models.csv;

namespace EuroMillions.Infrastructure.Mappers.ModelMappers;

public static class CsvDrawModelMap
{
    public static Draw ToModel(this CsvDrawModel csvDrawModel) => new Draw
    {
        Ball1 = csvDrawModel.Ball1,
        Ball2 = csvDrawModel.Ball2,
        Ball3 = csvDrawModel.Ball3,
        Ball4 = csvDrawModel.Ball4,
        Ball5 = csvDrawModel.Ball5,
        Star1 = csvDrawModel.Star1,
        Star2 = csvDrawModel.Star2,
        YearDrawNumber = csvDrawModel.YearDrawNumber,
        DrawDate = csvDrawModel.DrawDate
    };
}

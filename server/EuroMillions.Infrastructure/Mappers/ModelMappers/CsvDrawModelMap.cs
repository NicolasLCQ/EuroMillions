using EuroMillions.Application.Models;
using EuroMillions.Infrastructure.Models.csv;

namespace EuroMillions.Infrastructure.Mappers.ModelMappers;

public static class CsvDrawModelMap
{
    public static Draw ToEntity(this CsvDrawModel csvDrawModel) => new Draw(
        csvDrawModel.YearDrawNumber,
        csvDrawModel.DrawDate,
        csvDrawModel.Ball1,
        csvDrawModel.Ball2,
        csvDrawModel.Ball3,
        csvDrawModel.Ball4,
        csvDrawModel.Ball5,
        csvDrawModel.Star1,
        csvDrawModel.Star2
    );
}

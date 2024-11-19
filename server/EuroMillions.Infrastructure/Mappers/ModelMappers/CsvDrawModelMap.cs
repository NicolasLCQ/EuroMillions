namespace EuroMillions.Infrastructure.Mappers.ModelMappers;

using Data.Models;

using Models.csv;

public static class CsvDrawModelMap
{
    public static Draw ToEntity(this CsvDrawModel csvDrawModel) => new(csvDrawModel.Ball1, csvDrawModel.Ball2, csvDrawModel.Ball3, csvDrawModel.Ball4, csvDrawModel.Ball5, csvDrawModel.Star1, csvDrawModel.Star2);
}

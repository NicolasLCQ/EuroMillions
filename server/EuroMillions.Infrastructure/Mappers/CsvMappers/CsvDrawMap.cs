namespace EuroMillions.Infrastructure.Mappers.CsvMapper;

using CsvHelper.Configuration;

using Models.csv;

public sealed class CsvDrawMap : ClassMap<CsvDrawModel>
{
    public CsvDrawMap()
    {
        Map(draw => draw.Ball1).Name("boule_1");
        Map(draw => draw.Ball2).Name("boule_2");
        Map(draw => draw.Ball3).Name("boule_3");
        Map(draw => draw.Ball4).Name("boule_4");
        Map(draw => draw.Ball5).Name("boule_5");
        Map(draw => draw.Star1).Name("etoile_1");
        Map(draw => draw.Star2).Name("etoile_2");

        Map(draw => draw.YearDrawNumber).Name("annee_numero_de_tirage");
        Map(draw => draw.DrawDate).Name("date_de_tirage").TypeConverterOption.Format("yyyyMMdd", "dd/MM/yyyy", "dd/MM/yy");
    }
}

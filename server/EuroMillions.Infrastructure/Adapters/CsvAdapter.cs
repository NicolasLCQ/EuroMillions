using System.Globalization;

using CsvHelper;
using CsvHelper.Configuration;

using EuroMillions.Application.Interfaces.Infrastructure.Adapters;
using EuroMillions.Application.Models;
using EuroMillions.Infrastructure.Mappers.CsvMappers;
using EuroMillions.Infrastructure.Mappers.ModelMappers;
using EuroMillions.Infrastructure.Models.csv;

using Microsoft.AspNetCore.Http;

namespace EuroMillions.Infrastructure.Adapters;

public class CsvAdapter : ICsvAdapter
{
    private readonly CsvConfiguration _csvConfiguration = new CsvConfiguration(CultureInfo.GetCultureInfo("fr-FR"))
    {
        NewLine = "\n",
        Delimiter = ";",
        HasHeaderRecord = true,
        TrimOptions = TrimOptions.Trim
    };

    public List<Draw> ExtractEuroMillionDrawFromFile(IFormFile csvFormFile) =>
        ExtractEuroMillionDrawFromFile(csvFormFile.OpenReadStream());

    public List<Draw> ExtractEuroMillionDrawFromFile(Stream csvStream)
    {
        using StreamReader reader = new StreamReader(csvStream);
        using CsvReader csv = new CsvReader(reader, _csvConfiguration);

        csv.Context.RegisterClassMap<CsvDrawMap>();

        return csv.GetRecords<CsvDrawModel>().Select(draw => draw.ToDrawModel()).ToList();
    }
}

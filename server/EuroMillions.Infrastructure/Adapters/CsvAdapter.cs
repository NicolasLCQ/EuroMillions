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

//https://joshclose.github.io/CsvHelper/examples/reading/reading-multiple-data-sets/
public class CsvAdapter : ICsvAdapter
{
    private readonly CsvConfiguration _csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture)
    {
        NewLine = "\n",
        Delimiter = ";",
        HasHeaderRecord = true
    };

    public IList<Draw> ExtractEuroMillionDrawFromFileAsStream(IFormFile csvFormFile)
    {
        using StreamReader reader = new StreamReader(csvFormFile.OpenReadStream());
        using CsvReader csv = new CsvReader(reader, _csvConfiguration);

        csv.Context.RegisterClassMap<CsvDrawMap>();

        return csv.GetRecords<CsvDrawModel>().Select(draw => draw.ToEntity()).ToList();
    }
}

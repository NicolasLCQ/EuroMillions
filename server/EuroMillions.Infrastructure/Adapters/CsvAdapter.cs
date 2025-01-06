namespace EuroMillions.Infrastructure.Adapters;

using System.Globalization;

using Application.Models;

using CsvHelper;
using CsvHelper.Configuration;

using EuroMillions.Application.Interfaces.Infrastructure.Adapters;

using Data.Models;

using Mappers.CsvMapper;
using Mappers.ModelMappers;

using Models.csv;

//https://joshclose.github.io/CsvHelper/examples/reading/reading-multiple-data-sets/
public class CsvAdapter : ICsvAdapter
{
    private readonly CsvConfiguration _csvConfiguration = new(CultureInfo.InvariantCulture) { NewLine = "\n", Delimiter = ";", HasHeaderRecord = true };

    public IList<Draw> ExtractEuroMillionDrawFromFileAsStream(Stream csvReportFileStream)
    {
        using StreamReader reader = new(csvReportFileStream);
        using CsvReader csv = new(reader, _csvConfiguration);

        csv.Context.RegisterClassMap<CsvDrawMap>();
        return csv.GetRecords<CsvDrawModel>().Select(draw => draw.ToEntity()).ToList();
    }
}

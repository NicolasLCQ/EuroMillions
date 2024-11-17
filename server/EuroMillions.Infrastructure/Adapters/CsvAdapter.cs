namespace EuroMillions.Infrastructure.Adapters;

using System.Globalization;

using CsvHelper;
using CsvHelper.Configuration;

using EuroMillions.Application.Interfaces.Infrastructure.Adapters;
using EuroMillions.Data.Models;
using EuroMillions.Infrastructure.Mappers.CsvMapper;

//https://joshclose.github.io/CsvHelper/examples/reading/reading-multiple-data-sets/
public class CsvAdapter: ICsvAdapter
{
    private CsvConfiguration _csvConfiguration;

    public CsvAdapter()
    {
        _csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture) { NewLine = Environment.NewLine };
    }

    public IList<Draw> ExtractEuroMillionDrawFromStream(Stream csvReportFileStream)
    {
        using StreamReader reader = new StreamReader(csvReportFileStream);
        using CsvReader csv = new CsvReader(reader, _csvConfiguration);

        csv.Context.RegisterClassMap<CsvDrawMap>();
        return csv.GetRecords<Draw>().ToList();
    }
}

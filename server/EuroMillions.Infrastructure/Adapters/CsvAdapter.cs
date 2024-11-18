namespace EuroMillions.Infrastructure.Adapters;

using System.Globalization;

using CsvHelper;
using CsvHelper.Configuration;

using EuroMillions.Application.Interfaces.Infrastructure.Adapters;

using Data.Models;

using Mappers.CsvMapper;

using Models.csv;

//https://joshclose.github.io/CsvHelper/examples/reading/reading-multiple-data-sets/
public class CsvAdapter : ICsvAdapter
{
    private CsvConfiguration _csvConfiguration;

    public CsvAdapter()
    {
        _csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture) { NewLine = "\n", Delimiter = ";", HasHeaderRecord = true };
    }

    public IList<Draw> ExtractEuroMillionDrawFromFileAsStream(Stream csvReportFileStream)
    {
        using StreamReader reader = new(csvReportFileStream);
        using CsvReader csv = new(reader, _csvConfiguration);

        csv.Context.RegisterClassMap<CsvDrawMap>();
        List<CsvDrawModel> r = csv.GetRecords<CsvDrawModel>().ToList();
        var cc = csv.ColumnCount;
        var hr = csv.HeaderRecord;
        return new List<Draw>();
    }
}

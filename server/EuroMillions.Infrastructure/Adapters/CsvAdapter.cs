using System.Globalization;

using CsvHelper;

using EuroMillions.Application.Interfaces.Infrastructure.Adapters;
using EuroMillions.Application.Models;
using EuroMillions.Infrastructure.Mappers.ModelMappers;
using EuroMillions.Infrastructure.Models.csv;

namespace EuroMillions.Infrastructure.Adapters;

public class CsvAdapter : ICsvAdapter
{
    private static readonly CsvReaderOptions CsvOptions = new CsvReaderOptions
    {
        FormatProvider = CultureInfo.GetCultureInfo("fr-FR"),
        Separator = ';',
        HasHeader = true,
        TrimWhitespace = true,
        MalformedData = CsvMalformedDataHandling.Throw,
        MissingField = CsvMissingFieldHandling.Throw
    };

    public List<Draw> ExtractEuroMillionDrawFromFile(Stream csvStream)
    {
        using CsvReader csv = CsvReader.Create(csvStream, CsvOptions, leaveOpen: true);

        return csv.GetRecords<CsvDrawModel>().Select(draw => draw.ToDrawModel()).ToList();
    }
}

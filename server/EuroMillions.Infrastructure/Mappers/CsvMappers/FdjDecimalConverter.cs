using CsvHelper;

using EuroMillions.Infrastructure.Helpers;

namespace EuroMillions.Infrastructure.Mappers.CsvMappers;

public sealed class FdjDecimalConverter : ICsvConverter<decimal>
{
    public decimal Read(CsvReader reader, int index) =>
        StringHelpers.ParseNullableDecimal(reader.GetString(index)).GetValueOrDefault();

    public void Write(CsvWriter writer, decimal value) => writer.WriteField(value);
}

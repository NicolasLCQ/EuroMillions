using CsvHelper;

using EuroMillions.Infrastructure.Helpers;

namespace EuroMillions.Infrastructure.Mappers.CsvMappers;

public sealed class FdjIntConverter : ICsvConverter<int>
{
    public int Read(CsvReader reader, int index) =>
        StringHelpers.ParseNullableIntOrNull(reader.GetString(index)).GetValueOrDefault();

    public void Write(CsvWriter writer, int value) => writer.WriteField(value);
}

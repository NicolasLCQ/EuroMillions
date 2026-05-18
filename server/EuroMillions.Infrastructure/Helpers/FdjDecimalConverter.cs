using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

using EuroMillions.Infrastructure.Helpers;

namespace EuroMillions.Infrastructure.Mappers.CsvMappers;

public class FdjDecimalConverter : DefaultTypeConverter
{
    public override object ConvertFromString(string? text, IReaderRow row, MemberMapData memberMapData) =>
        StringHelpers.ParseNullableDecimal(text).GetValueOrDefault();
}

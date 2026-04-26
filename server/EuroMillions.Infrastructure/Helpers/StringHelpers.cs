using System.Globalization;

namespace EuroMillions.Infrastructure.Helpers;

public static class StringHelpers
{
    public static int? ParseNullableIntOrNull(string? text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return null;
        }

        string cleaned = text.Trim().Replace(" ", string.Empty).Replace("\u00A0", string.Empty);

        return int.TryParse(cleaned, NumberStyles.Integer, CultureInfo.InvariantCulture, out int value)
            ? value
            : null;
    }

    public static decimal? ParseNullableDecimal(string? text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return null;
        }

        string cleaned = text.Trim().Replace(" ", string.Empty).Replace("\u00A0", string.Empty);

        if (cleaned.StartsWith(",") || cleaned.StartsWith("."))
        {
            cleaned = "0" + cleaned;
        }

        if (cleaned.Contains(',') && cleaned.Contains('.'))
        {
            int lastComma = cleaned.LastIndexOf(',');
            int lastDot = cleaned.LastIndexOf('.');
            bool commaIsDecimal = lastComma > lastDot;

            cleaned = commaIsDecimal
                ? cleaned.Replace(".", string.Empty).Replace(',', '.')
                : cleaned.Replace(",", string.Empty);
        }
        else
        {
            cleaned = cleaned.Replace(',', '.');
        }

        if (
            decimal.TryParse(
                cleaned,
                NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint,
                CultureInfo.InvariantCulture,
                out decimal value
            )
        )
        {
            return value;
        }

        throw new FormatException($"Invalid decimal value: '{text}'.");
    }
}

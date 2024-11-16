namespace EuroMillions.Gateway.Adapters;

using System.Globalization;

using CsvHelper.Configuration;

public class CsvAdapter
{
    private CsvConfiguration _csvConfiguration;
    //https://joshclose.github.io/CsvHelper/examples/reading/reading-multiple-data-sets/
    public CsvAdapter()
    {
        _csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture) { NewLine = Environment.NewLine };
    }
}

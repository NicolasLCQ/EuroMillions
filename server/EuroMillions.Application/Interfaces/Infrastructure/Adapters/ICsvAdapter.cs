namespace EuroMillions.Application.Interfaces.Infrastructure.Adapters;

using Data.Models;

public interface ICsvAdapter
{
    public IEnumerable<Draw> ExtractEuroMillionDrawFromFileAsStream(Stream csvReportFileStream);
}

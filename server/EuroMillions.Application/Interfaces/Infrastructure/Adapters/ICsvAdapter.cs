namespace EuroMillions.Application.Interfaces.Infrastructure.Adapters;

using Data.Models;

public interface ICsvAdapter
{
    public IList<Draw> ExtractEuroMillionDrawFromStream(Stream csvReportFileStream);
}

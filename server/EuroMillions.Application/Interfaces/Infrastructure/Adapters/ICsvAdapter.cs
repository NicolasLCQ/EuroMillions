namespace EuroMillions.Application.Interfaces.Infrastructure.Adapters;

using System.Collections;

using Data.Models;

public interface ICsvAdapter
{
    public IList<Draw> ExtractEuroMillionDrawFromFileAsStream(Stream csvReportFileStream);
}

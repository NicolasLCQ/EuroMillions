using EuroMillions.Application.Models;

namespace EuroMillions.Application.Interfaces.Infrastructure.Adapters;

public interface ICsvAdapter
{
    List<Draw> ExtractEuroMillionDrawFromFile(Stream csvStream);
}

namespace EuroMillions.Application.Services;

using Data.Models;

using Interfaces;
using Interfaces.Infrastructure.Adapters;
using Interfaces.Services;

public class DrawServices(ICsvAdapter csvAdapter) : IDrawServices
{
    public async void AddDrawsFromCsvFiles(IEnumerable<Stream> fileStreams)
    {
        IEnumerable<Draw> drawsToAdd = fileStreams
            .SelectMany(fileStream => csvAdapter.ExtractEuroMillionDrawFromFileAsStream(fileStream))
            .ToList();
    }
}

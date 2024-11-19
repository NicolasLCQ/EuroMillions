namespace EuroMillions.Application.Services;

using Data.Models;

using Interfaces;
using Interfaces.Infrastructure.Adapters;
using Interfaces.Services;

public class DrawServices(ICsvAdapter csvAdapter) : IDrawServices
{
    public async void AddDrawsFromCsvFiles(IEnumerable<Stream> fileStreams)
    {
        //add a function that takes multiples streams to avoid to many code in Application
        IList<Draw> drawsToAdd = fileStreams
            .SelectMany(fileStream => csvAdapter.ExtractEuroMillionDrawFromFileAsStream(fileStream))
            .ToList();
    }
}

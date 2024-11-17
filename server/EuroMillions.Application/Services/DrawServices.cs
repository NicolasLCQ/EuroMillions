namespace EuroMillions.Application.Services;

using Data.Models;

using Interfaces;
using Interfaces.Infrastructure.Adapters;
using Interfaces.Services;

public class DrawServices(ICsvAdapter csvAdapter) : IDrawServices
{
    public async void AddDrawsFromCsvFiles(IEnumerable<Stream> fileStreams)
    {
        fileStreams.SelectMany(fileStream => csvAdapter
                        .ExtractEuroMillionDrawFromStream(fileStream))
                        .ToList()
                        .ForEach(draw => Console.WriteLine(draw)
                    );
    }
}

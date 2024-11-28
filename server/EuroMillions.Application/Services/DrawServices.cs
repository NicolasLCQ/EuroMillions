namespace EuroMillions.Application.Services;

using Data.Models;

using Interfaces.Infrastructure.Adapters;
using Interfaces.Infrastructure.Repositories;
using Interfaces.Services;

public class DrawServices(ICsvAdapter csvAdapter, IDrawRepository drawRepository) : IDrawServices
{
    public async Task AddDrawsFromCsvFilesAsync(IEnumerable<Stream> fileStreams)
    {
        IEnumerable<Draw> drawsToAdd = fileStreams
            .SelectMany(fileStream => csvAdapter.ExtractEuroMillionDrawFromFileAsStream(fileStream))
            .ToList();

        await drawRepository.AddDrawsAsync(drawsToAdd);
    }
}

namespace EuroMillions.Application.Services;

using Data.Models;

using Interfaces.Infrastructure.Adapters;
using Interfaces.Infrastructure.Repositories;
using Interfaces.Services;

public class DrawServices(ICsvAdapter csvAdapter, IDrawRepository drawRepository) : IDrawServices
{
    public async Task<int> AddDrawsFromCsvFilesAsync(IEnumerable<Stream> fileStreams)
    {
        IEnumerable<Draw> drawsFromFiles = fileStreams
            .SelectMany(fileStream => csvAdapter.ExtractEuroMillionDrawFromFileAsStream(fileStream))
            .ToList();

        IEnumerable<Draw> drawsToAdd = await drawRepository.FilterNewDrawsAsync(drawsFromFiles);

        return await drawRepository.AddDrawsAsync(drawsToAdd);
    }
}

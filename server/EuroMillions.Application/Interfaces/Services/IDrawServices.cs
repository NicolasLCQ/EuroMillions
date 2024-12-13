namespace EuroMillions.Application.Interfaces.Services;

public interface IDrawServices
{
    public Task<int> AddDrawsFromCsvFilesAsync(IEnumerable<Stream> fileStreams);
}

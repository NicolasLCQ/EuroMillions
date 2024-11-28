namespace EuroMillions.Application.Interfaces.Services;

public interface IDrawServices
{
    public Task AddDrawsFromCsvFilesAsync(IEnumerable<Stream> fileStreams);
}

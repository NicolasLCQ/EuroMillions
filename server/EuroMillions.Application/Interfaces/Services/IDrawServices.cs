namespace EuroMillions.Application.Interfaces.Services;

public interface IDrawServices
{
    //todo: async
    public void AddDrawsFromCsvFiles(IEnumerable<Stream> fileStreams);
}

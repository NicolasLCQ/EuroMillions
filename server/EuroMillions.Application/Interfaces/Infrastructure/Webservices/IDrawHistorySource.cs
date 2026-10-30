using EuroMillions.Application.Models.Upload;

namespace EuroMillions.Application.Interfaces.Infrastructure.Webservices;

public interface IDrawHistorySource
{
    /// <summary>Retrieves and parses draw history files.</summary>
    /// <returns>The source file names and their draws.</returns>
    Task<List<DrawFileModel>> GetDrawFilesAsync();
}

namespace EuroMillions.Application.Interfaces.Infrastructure.Adapters;

public interface IFileAdapter
{
    Task UnzipAsync(string zipFilePath, string extractPath);
    Task DeleteFileAsync(string filePath);
    Task DeleteDirectoryAsync(string directoryPath);
    Task<IEnumerable<string>> GetFilesInDirectoryAsync(string directoryPath);

    Task<Stream> ReadFileAsync(string filePath);
}

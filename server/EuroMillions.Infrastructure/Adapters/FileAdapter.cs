using System.IO.Compression;

using EuroMillions.Application.Interfaces.Infrastructure.Adapters;

namespace EuroMillions.Infrastructure.Adapters;

public class FileAdapter : IFileAdapter
{
    public async Task UnzipAsync(string zipFilePath, string extractPath)
    {
        await ZipFile.ExtractToDirectoryAsync(zipFilePath, extractPath);
    }

    public Task DeleteFileAsync(string filePath)
    {
        File.Delete(filePath);
        return Task.CompletedTask;
    }

    public Task DeleteDirectoryAsync(string directoryPath)
    {
        Directory.Delete(directoryPath, true);
        return Task.CompletedTask;
    }

    public Task<IEnumerable<string>> GetFilesInDirectoryAsync(string directoryPath) =>
        Task.FromResult(Directory.EnumerateFiles(directoryPath));

    public Task<Stream> ReadFileAsync(string filePath) => Task.FromResult<Stream>(File.OpenRead(filePath));
}

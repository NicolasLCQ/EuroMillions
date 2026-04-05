using System.IO.Compression;
using EuroMillions.Application.Interfaces.Infrastructure.Adapters;

namespace EuroMillions.Infrastructure.Adapters;

public class FileAdapter : IFileAdapter
{
    public void WriteFile(string filePath, byte[] bytes)
    {
        File.WriteAllBytes(filePath, bytes);
    }

    public void Unzip(string zipFilePath, string extractPath)
    {
        ZipFile.ExtractToDirectory(zipFilePath, extractPath);
    }
}

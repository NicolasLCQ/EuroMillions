namespace EuroMillions.Application.Interfaces.Infrastructure.Adapters;

public interface IFileAdapter
{
    void WriteFile(string filePath, byte[] bytes);
    void Unzip(string zipFilePath, string extractPath);
}

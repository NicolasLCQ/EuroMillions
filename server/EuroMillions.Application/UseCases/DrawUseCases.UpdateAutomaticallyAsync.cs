using EuroMillions.Application.Consts;
using EuroMillions.Application.Helpers;
using EuroMillions.Application.Models.Upload;

namespace EuroMillions.Application.UseCases;

public partial class DrawUseCases
{
    public async Task<string> UpdateAutomaticallyAsync()
    {
        string html = await httpWebService.GetHtmlAsync(FdjConsts.HistoryPageUrl);
        IEnumerable<string> hrefs = HtmlHelper.ExtractAllHrefsFromHtml(html);

        IEnumerable<string> absoluteLinks
            = HtmlHelper.ConvertHrefsToAbsolutLinks(hrefs, new Uri(FdjConsts.HistoryPageUrl));

        IEnumerable<string> historyFileLinks = FdjScraperHelper.FilterHistoryFileDownloadLinksFromLinks(absoluteLinks);

        string tempFolder = Path.GetTempPath();
        string workingDirectory = Path.Combine(tempFolder, $"EuroMillions{Guid.NewGuid()}");
        string downloadDirectory = Path.Combine(workingDirectory, "Download");
        string unzipDirectory = Path.Combine(workingDirectory, "Unzipped");

        Directory.CreateDirectory(downloadDirectory);
        Directory.CreateDirectory(unzipDirectory);

        List<Task> downloadAndUnzipTasks = historyFileLinks.Select(async link =>
                {
                    byte[] zipFile = await httpWebService.DownloadAsync(link);
                    string fileName = Path.GetFileName(link);
                    string zipFilePath = Path.Combine(downloadDirectory, fileName);

                    await File.WriteAllBytesAsync(zipFilePath, zipFile);
                    await fileAdapter.UnzipAsync(zipFilePath, unzipDirectory);
                    await fileAdapter.DeleteFileAsync(zipFilePath);
                }
            )
            .ToList();

        await Task.WhenAll(downloadAndUnzipTasks);
        await fileAdapter.DeleteDirectoryAsync(downloadDirectory);

        IEnumerable<string> unzipFilePaths = await fileAdapter.GetFilesInDirectoryAsync(unzipDirectory);

        List<Task<DrawFileModel>> drawFileModelTasks = unzipFilePaths
            .Select(async filePath =>
                {
                    Stream fileStream = await fileAdapter.ReadFileAsync(filePath);

                    return new DrawFileModel
                    {
                        FileName = Path.GetFileName(filePath), Draws = csvAdapter.ExtractEuroMillionDrawFromFile(fileStream)
                    };
                }
            )
            .ToList();

        await Task.WhenAll(drawFileModelTasks);
        await fileAdapter.DeleteDirectoryAsync(unzipDirectory);

        List<DrawFileModel> drawFileModels = drawFileModelTasks.Select(t => t.Result).ToList();
        await drawRepository.AddDrawsFromDrawFileModelsAsync(drawFileModels);
        return unzipDirectory;
    }
}

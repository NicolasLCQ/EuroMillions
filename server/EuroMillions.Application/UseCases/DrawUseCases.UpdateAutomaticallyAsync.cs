using EuroMillions.Application.Consts;
using EuroMillions.Application.Helpers;
using EuroMillions.Application.Models.Upload;

namespace EuroMillions.Application.UseCases;

public partial class DrawUseCases
{
    public async Task<UploadResultModel> UpdateAutomaticallyAsync()
    {
        string html = await httpWebService.GetHtmlAsync(FdjConsts.HistoryPageUrl);
        IEnumerable<string> hrefs = HtmlHelper.ExtractAllHrefsFromHtml(html);

        IEnumerable<string> absoluteLinks
            = HtmlHelper.ConvertHrefsToAbsolutLinks(hrefs, new Uri(FdjConsts.HistoryPageUrl));

        List<string> historyFileLinks = FdjScraperHelper.FilterHistoryFileDownloadLinksFromLinks(absoluteLinks).ToList();

        string tempFolder = Path.GetTempPath();
        string workingDirectory = Path.Combine(tempFolder, $"EuroMillions{Guid.NewGuid()}");
        string downloadDirectory = Path.Combine(workingDirectory, "Download");
        string unzipDirectory = Path.Combine(workingDirectory, "Unzipped");

        Directory.CreateDirectory(downloadDirectory);
        Directory.CreateDirectory(unzipDirectory);

        await Parallel.ForEachAsync(
            historyFileLinks,
            async (link, cancellationToken) =>
            {
                byte[] zipFile = await httpWebService.DownloadAsync(link);
                string fileName = Path.GetFileName(link);
                string zipFilePath = Path.Combine(downloadDirectory, fileName);

                await File.WriteAllBytesAsync(zipFilePath, zipFile, cancellationToken);
                await fileAdapter.UnzipAsync(zipFilePath, unzipDirectory);
                await fileAdapter.DeleteFileAsync(zipFilePath);
            }
        );

        await fileAdapter.DeleteDirectoryAsync(downloadDirectory);

        List<string> unzipFilePaths = (await fileAdapter.GetFilesInDirectoryAsync(unzipDirectory)).ToList();

        List<Task<DrawFileModel>> drawFileModelTasks = unzipFilePaths
            .Select(async unzipFilePath =>
                {
                    await using Stream fileStream = await fileAdapter.ReadFileAsync(unzipFilePath);

                    return new DrawFileModel
                    {
                        FileName = Path.GetFileName(unzipFilePath),
                        Draws = csvAdapter.ExtractEuroMillionDrawFromFile(fileStream)
                    };
                }
            )
            .ToList();

        await Task.WhenAll(drawFileModelTasks);

        List<DrawFileModel> drawFileModels = drawFileModelTasks.Select(t => t.Result).ToList();

        UploadResultModel uploadResult = await AddDrawsWithDeduplicationAsync(drawFileModels);

        await fileAdapter.DeleteDirectoryAsync(unzipDirectory);
        return uploadResult;
    }
}

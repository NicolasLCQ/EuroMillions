using EuroMillions.Application.Interfaces.Infrastructure.Adapters;
using EuroMillions.Application.Interfaces.Infrastructure.Webservices;
using EuroMillions.Application.Models.Upload;
using EuroMillions.Infrastructure.Consts;
using EuroMillions.Infrastructure.Helpers;

namespace EuroMillions.Infrastructure.Webservices;

public class FdjDrawHistorySource(
    IHttpWebService httpWebService,
    IFileAdapter fileAdapter,
    ICsvAdapter csvAdapter
) : IDrawHistorySource
{
    public async Task<List<DrawFileModel>> GetDrawFilesAsync()
    {
        string html = await httpWebService.GetHtmlAsync(FdjConsts.HistoryPageUrl);
        IEnumerable<string> hrefs = HtmlHelper.ExtractAllHrefsFromHtml(html);

        IEnumerable<string> absoluteLinks
            = HtmlHelper.ConvertHrefsToAbsolutLinks(hrefs, new Uri(FdjConsts.HistoryPageUrl));

        List<string> historyFileLinks = FdjScraperHelper.FilterHistoryFileDownloadLinksFromLinks(absoluteLinks)
            .DeduplicateLinks();

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

        await fileAdapter.DeleteDirectoryAsync(unzipDirectory);
        return drawFileModels;
    }
}

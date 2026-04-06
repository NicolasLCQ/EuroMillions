using EuroMillions.Application.Consts;
using EuroMillions.Application.Helpers;

namespace EuroMillions.Application.UseCases;

public partial class DrawUseCases
{
    public async Task<List<string>> UpdateAutomaticallyAsync()
    {
        string html = await httpWebService.GetHtmlAsync(FdjConsts.HistoryPageUrl);
        IEnumerable<string> hrefs = HtmlHelper.ExtractAllHrefsFromHtml(html);

        IEnumerable<string> absoluteLinks
            = HtmlHelper.ConvertHrefsToAbsolutLinks(hrefs, new Uri(FdjConsts.HistoryPageUrl));

        IEnumerable<string> historyFileLinks = FdjScraperHelper.FilterHistoryFileDownloadLinksFromLinks(absoluteLinks);

        string tempFolder = Path.GetTempPath();
        string workingDirectory = Path.Combine(tempFolder, $"EuroMillions{Guid.NewGuid()}");

        string downloadDirectory = Path.Combine(workingDirectory, "Download");
        Directory.CreateDirectory(downloadDirectory);

        IEnumerable<Task> downloadTasks = historyFileLinks.Select(async link =>
            {
                byte[] zipFile = await httpWebService.DownloadAsync(link);

                string tempFilePath = Path.Combine(downloadDirectory, Path.GetFileName(link));
                await File.WriteAllBytesAsync(tempFilePath, zipFile);
            }
        );

        await Task.WhenAll(downloadTasks);

        //unzip file from working directory

        return [];
    }
}

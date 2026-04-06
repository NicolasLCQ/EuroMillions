using EuroMillions.Application.Consts;
using EuroMillions.Application.Helpers;

namespace EuroMillions.Application.UseCases;

public partial class DrawUseCases
{
    public async Task<List<string>> UpdateAutomaticallyAsync()
    {
        string html = await httpWebService.GetHtmlAsync(FdjHistoryLinksConsts.HistoryPageUrl);
        IEnumerable<string> hrefs = HtmlHelper.ExtractAllHrefsFromHtml(html);

        IEnumerable<string> absoluteLinks
            = HtmlHelper.ConvertHrefsToAbsolutLinks(hrefs, new Uri(FdjHistoryLinksConsts.HistoryPageUrl));

        IEnumerable<string> historyFileLinks = FdjScraperHelper.FilterHistoryFileDownloadLinksFromLinks(absoluteLinks);

        //dowload history files as zip into temp folder
        historyFileLinks.ToList()
            .ForEach(async link =>
            {
                byte[] zipFile = await httpWebService.DownloadAsync(link);
                string tempFolder = Path.GetTempPath();
                string workingDirectory = Path.Combine(tempFolder, $"EuroMillions{Guid.NewGuid()}");
                Directory.CreateDirectory(workingDirectory);
                string tempFilePath = Path.Combine(workingDirectory, Path.GetFileName(link));
                await File.WriteAllBytesAsync(tempFilePath, zipFile);

            });

        return historyFileLinks.Distinct(StringComparer.OrdinalIgnoreCase).ToList();
    }
}

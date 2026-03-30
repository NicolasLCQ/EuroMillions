using EuroMillions.Application.Consts;
using EuroMillions.Application.Helpers;

namespace EuroMillions.Application.UseCases;

public partial class DrawUseCases
{
    public async Task<List<string>> GetHistoryDownloadLinksAsync()
    {
        string html = await httpWebService.GetHtmlFrom(FdjHistoryLinksConsts.HistoryPageUrl);
        IEnumerable<string> hrefs = HtmlHelper.ExtractAllHrefsFromHtml(html);

        IEnumerable<string> absoluteLinks
            = HtmlHelper.ConvertHrefsToAbsolutLinks(hrefs, new Uri(FdjHistoryLinksConsts.HistoryPageUrl));

        IEnumerable<string> historyFileLinks = FdjScraperHelper.FilterHistoryFileDownloadLinksFromLinks(absoluteLinks);

        return historyFileLinks.Distinct(StringComparer.OrdinalIgnoreCase).ToList();
    }
}

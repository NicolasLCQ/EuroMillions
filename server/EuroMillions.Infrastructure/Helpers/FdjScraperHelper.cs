using System.Text.RegularExpressions;

using EuroMillions.Infrastructure.Consts;

namespace EuroMillions.Infrastructure.Helpers;

public static class FdjScraperHelper
{
    private static readonly Regex HistoryFileLinkRegex = new Regex(
        FdjConsts.HistoryFileLinkPattern,
        RegexOptions.IgnoreCase | RegexOptions.Compiled
    );

    public static IEnumerable<string> FilterHistoryFileDownloadLinksFromLinks(IEnumerable<string> links)
    {
        return links.Where(link => HistoryFileLinkRegex.IsMatch(link));
    }

    public static List<string> DeduplicateLinks(this IEnumerable<string> links) =>
        links.Distinct(StringComparer.OrdinalIgnoreCase).ToList();
}

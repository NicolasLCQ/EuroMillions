using System.Net;
using System.Text.RegularExpressions;

using EuroMillions.Application.Consts;

namespace EuroMillions.Application.Helpers;

public static class HtmlHelper
{
    private static readonly Regex HrefRegex = new Regex(
        HtmlConsts.HrefPattern,
        RegexOptions.IgnoreCase | RegexOptions.Compiled
    );

    public static IEnumerable<string> ExtractAllHrefsFromHtml(string html) =>
        HrefRegex.Matches(html)
            .Select(m => m.Groups["href"].Value.Trim())
            .Where(href => !string.IsNullOrWhiteSpace(href));

    public static IEnumerable<string> ConvertHrefsToAbsolutLinks(
        IEnumerable<string> hrefs,
        Uri baseUrl
    ) =>
        hrefs
            .Select(href => WebUtility.HtmlDecode(href).Trim())
            .Where(decodedHref => Uri.TryCreate(baseUrl, decodedHref, out _))
            .Select(decodedHref => new Uri(baseUrl, decodedHref).AbsoluteUri);
}

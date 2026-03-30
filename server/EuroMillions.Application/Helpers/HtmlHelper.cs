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

    public static IEnumerable<string> ExtractAllHrefsFromHtml(string html)
    {
        foreach (Match hrefMatch in HrefRegex.Matches(html))
        {
            string href = hrefMatch.Groups["href"].Value.Trim();

            if (!string.IsNullOrWhiteSpace(href))
            {
                yield return href;
            }
        }
    }

    public static IEnumerable<string> ConvertHrefsToAbsolutLinks(
        IEnumerable<string> hrefs,
        Uri baseUrl
    )
    {
        foreach (string href in hrefs)
        {
            string decodedHref = WebUtility.HtmlDecode(href).Trim();

            if (Uri.TryCreate(baseUrl, decodedHref, out Uri? absoluteUri))
            {
                yield return absoluteUri.AbsoluteUri;
            }
        }
    }
}

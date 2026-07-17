using EuroMillions.Application.Consts;

namespace EuroMillions.Infrastructure.Helpers;

public static class HttpHelper
{
    private const string UserAgent =
        "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/126.0 Safari/537.36";

    public static HttpRequestMessage CreateHttpRequest(string url, string accept)
    {
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);

        request.Headers.TryAddWithoutValidation("User-Agent", UserAgent);
        request.Headers.TryAddWithoutValidation("Accept", accept);
        request.Headers.TryAddWithoutValidation("Accept-Language", "fr-FR,fr;q=0.9,en;q=0.8");
        request.Headers.Referrer = new Uri(FdjConsts.HistoryPageUrl);

        return request;
    }
}

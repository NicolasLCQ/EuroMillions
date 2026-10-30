using EuroMillions.Infrastructure.Consts;
using EuroMillions.Application.Interfaces.Infrastructure.Webservices;
using EuroMillions.Infrastructure.Helpers;

namespace EuroMillions.Infrastructure.Webservices;

public class HttpWebService(HttpClient httpClient) : IHttpWebService
{
    public async Task<string> GetHtmlAsync(string url)
    {
        using HttpRequestMessage request = HttpHelper.CreateHttpRequest(
            url,
            HtmlConsts.HtmlAcceptHeader
        );

        using HttpResponseMessage response = await httpClient.SendAsync(request);

        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }

    public async Task<byte[]> DownloadAsync(string url)
    {
        using HttpRequestMessage request = HttpHelper.CreateHttpRequest(
            url,
            HtmlConsts.DownloadAcceptHeader
        );

        using HttpResponseMessage response = await httpClient.SendAsync(request);

        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsByteArrayAsync();
    }
}

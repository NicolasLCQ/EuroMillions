using EuroMillions.Application.Interfaces.Infrastructure.Webservices;

namespace EuroMillions.Infrastructure.Webservices;

public class HttpWebService(HttpClient httpClient) : IHttpWebService
{
    public async Task<string> GetHtmlFrom(string url) => await httpClient.GetStringAsync(url);

    public async Task<byte[]> DownloadFrom(string url) => await httpClient.GetByteArrayAsync(url);
}

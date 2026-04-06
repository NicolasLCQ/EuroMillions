using EuroMillions.Application.Interfaces.Infrastructure.Webservices;

namespace EuroMillions.Infrastructure.Webservices;

public class HttpWebService(HttpClient httpClient) : IHttpWebService
{
    public async Task<string> GetHtmlAsync(string url) => await httpClient.GetStringAsync(url);

    public async Task<byte[]> DownloadAsync(string url) => await httpClient.GetByteArrayAsync(url);
}

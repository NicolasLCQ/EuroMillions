using EuroMillions.Application.Interfaces.Infrastructure.Webservices;

namespace EuroMillions.Infrastructure.Webservices;

public class HttpWebService(HttpClient httpClient) : IHttpWebService
{
    public async Task<string> GetHtmlFrom(string url)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(url);
        return await httpClient.GetStringAsync(url);
    }
}

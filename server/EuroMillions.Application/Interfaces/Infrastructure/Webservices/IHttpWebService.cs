namespace EuroMillions.Application.Interfaces.Infrastructure.Webservices;

public interface IHttpWebService
{
    Task<string> GetHtmlAsync(string url);
    Task<byte[]> DownloadAsync(string url);
}

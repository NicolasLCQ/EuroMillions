namespace EuroMillions.Application.Interfaces.Infrastructure.Webservices;

public interface IHttpWebService
{
    Task<string> GetHtmlFrom(string url);
}

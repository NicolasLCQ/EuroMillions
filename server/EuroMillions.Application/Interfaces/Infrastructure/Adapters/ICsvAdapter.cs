using EuroMillions.Application.Models;

using Microsoft.AspNetCore.Http;

namespace EuroMillions.Application.Interfaces.Infrastructure.Adapters;

public interface ICsvAdapter
{
    IList<Draw> ExtractEuroMillionDrawFromFileAsStream(IFormFile csvFormFile);
}

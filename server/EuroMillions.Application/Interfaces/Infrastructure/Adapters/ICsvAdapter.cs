namespace EuroMillions.Application.Interfaces.Infrastructure.Adapters;

using System.Collections;

using Microsoft.AspNetCore.Http;

using Models;

public interface ICsvAdapter
{
    public IList<Draw> ExtractEuroMillionDrawFromFileAsStream(IFormFile csvFormFile);
}

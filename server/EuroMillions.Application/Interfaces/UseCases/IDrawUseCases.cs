using EuroMillions.Application.Models;
using EuroMillions.Application.Models.Upload;

using Microsoft.AspNetCore.Http;

namespace EuroMillions.Application.Interfaces.UseCases;

public interface IDrawUseCases
{
    Task<List<UploadResultModel>> UploadDrawsFromCsvFilesAsync(IFormFileCollection uploadFileModels);
    Task<Draw?> GetLastDrawAsync();
}

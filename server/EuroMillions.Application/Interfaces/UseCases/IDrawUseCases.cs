using EuroMillions.Application.Models;
using EuroMillions.Application.Models.Upload;

using Microsoft.AspNetCore.Http;

namespace EuroMillions.Application.Interfaces.UseCases;

public interface IDrawUseCases
{
    Task<List<UploadResultSimpleModel>> UploadDrawsFromCsvFilesAsync(IFormFileCollection uploadFileModels);
    Task<Draw?> GetLastDrawAsync();
    Task<bool> AreUpToDateAsync();
    Task<UploadResultModel> UpdateAutomaticallyAsync();
}

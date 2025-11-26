using Microsoft.AspNetCore.Http;

using EuroMillions.Application.Models;

namespace EuroMillions.Application.Interfaces.Services;

public interface IUploadServices
{
    Task<List<UploadResultModel>> UploadDrawsFromCsvFilesAsync(IFormFileCollection uploadFileModels);
}

using EuroMillions.Application.Models;

using Microsoft.AspNetCore.Http;

namespace EuroMillions.Application.Interfaces.Services;

public interface IUploadServices
{
    Task<List<UploadResultModel>> UploadDrawsFromCsvFilesAsync(IFormFileCollection uploadFileModels);
}

using EuroMillions.Application.Models;
using EuroMillions.Application.Models.Upload;

namespace EuroMillions.Application.Interfaces.Infrastructure.Repositories;

public interface IDrawRepository
{
    Task<List<UploadResultModel>> AddDrawsFromDrawFileModelsAsync(List<DrawFileModel> drawFileModels);
}

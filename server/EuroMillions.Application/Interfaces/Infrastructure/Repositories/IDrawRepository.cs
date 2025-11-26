using EuroMillions.Application.Models;

namespace EuroMillions.Application.Interfaces.Infrastructure.Repositories;

public interface IDrawRepository
{
    Task<List<UploadResultModel>> AddDrawsFromDrawFileModelsAsync(List<DrawFileModel> drawFileModels);
}

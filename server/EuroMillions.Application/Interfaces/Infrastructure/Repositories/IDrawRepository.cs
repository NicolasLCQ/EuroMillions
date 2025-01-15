namespace EuroMillions.Application.Interfaces.Infrastructure.Repositories;

using Models;

public interface IDrawRepository
{
    public Task<List<UploadResultModel>> AddDrawsFromDrawFileModelsAsync(List<DrawFileModel> drawFileModels);
}

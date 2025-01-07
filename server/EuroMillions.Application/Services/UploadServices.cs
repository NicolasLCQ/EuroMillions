namespace EuroMillions.Application.Services;

using Interfaces.Infrastructure.Adapters;
using Interfaces.Infrastructure.Repositories;
using Interfaces.Services;

using Models;

public class UploadServices(ICsvAdapter csvAdapter, IDrawRepository drawRepository) : IUploadServices
{
    public async Task<List<DrawFileModel>> UploadDrawsFromCsvFilesAsync(IEnumerable<UploadFileModel> uploadFileModels)
    {
        List<DrawFileModel> drawFileModels = uploadFileModels.Select(ufm => new DrawFileModel { FileName = ufm.FileName, Draws = csvAdapter.ExtractEuroMillionDrawFromFileAsStream(ufm.FileSream).ToList() })
            .ToList();

        List<DrawFileModel> filteredDrawFileModels = drawFileModels.Select(async dfm => new DrawFileModel() { FileName = dfm.FileName, Draws = (await drawRepository.FilterNewDrawsAsync(dfm.Draws)).ToList() })
            .Select(asyncTask => asyncTask.Result)
            .ToList();

        foreach (DrawFileModel dfm in filteredDrawFileModels)
        {
            await drawRepository.AddDrawsAsync(dfm.Draws);
        }

        return filteredDrawFileModels;
    }
}

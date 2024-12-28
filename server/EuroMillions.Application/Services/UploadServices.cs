namespace EuroMillions.Application.Services;

using Data.Models;

using Interfaces.Infrastructure.Adapters;
using Interfaces.Infrastructure.Repositories;
using Interfaces.Services;

public class UploadServices(ICsvAdapter csvAdapter, IDrawRepository drawRepository) : IUploadServices
{
    /// <summary>
    /// Take a List UploadFileModels filter with only new elements and return an asynchronous list of {filename, addedDraws}
    /// </summary>
    /// <param name="uploadFileModels"></param>
    /// <returns>
    /// Task List of DrawFileModel
    /// </returns>
    public async Task<List<DrawFileModel>> UploadDrawsFromCsvFilesAsync(IEnumerable<UploadFileModel> uploadFileModels)
    {
        List<DrawFileModel> drawFileModels = uploadFileModels.Select(ufm => new DrawFileModel
            {
                FileName = ufm.FileName,
                Draws = csvAdapter.ExtractEuroMillionDrawFromFileAsStream(ufm.FileSream).ToList(),
            })
            .ToList();

        List<DrawFileModel> filteredDrawFileModels = drawFileModels.Select(async dfm => new DrawFileModel()
        {
            FileName = dfm.FileName,
            Draws = (await drawRepository.FilterNewDrawsAsync(dfm.Draws)).ToList(),
        })
            .Select(asyncTask => asyncTask.Result)
        .ToList();

        //trouver comment faire du one by one
        filteredDrawFileModels.ForEach(async dfm =>await drawRepository.AddDrawsAsync(dfm.Draws));

        return filteredDrawFileModels;
    }
}

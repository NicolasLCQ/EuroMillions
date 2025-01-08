namespace EuroMillions.Application.Services;

using Interfaces.Infrastructure.Adapters;
using Interfaces.Infrastructure.Repositories;
using Interfaces.Services;

using Models;

public class UploadServices(ICsvAdapter csvAdapter, IDrawRepository drawRepository) : IUploadServices
{
    public async Task<List<UploadResultModel>> UploadDrawsFromCsvFilesAsync(IEnumerable<UploadFileModel> uploadFileModels)
    {
        List<DrawFileModel> drawFileModels = uploadFileModels.Select(ufm => new DrawFileModel { FileName = ufm.FileName, Draws = csvAdapter.ExtractEuroMillionDrawFromFileAsStream(ufm.FileSream).ToList() })
            .ToList();

        List<UploadResultModel> uploadResultDraws = drawFileModels.Select(async dfm => new UploadResultModel() { FileName = dfm.FileName, AcceptedDraws = (await drawRepository.FilterNewDrawsAsync(dfm.Draws)).ToList(), RejectedDraws = (await drawRepository.FilterOldDrawsAsync(dfm.Draws)).ToList() })
            .Select(asyncTask => asyncTask.Result)
            .ToList();

        foreach (UploadResultModel ufm in uploadResultDraws)
        {
            await drawRepository.AddDrawsAsync(ufm.AcceptedDraws);
        }

        return uploadResultDraws;
    }
}

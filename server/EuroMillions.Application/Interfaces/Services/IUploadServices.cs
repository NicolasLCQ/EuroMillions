namespace EuroMillions.Application.Interfaces.Services;

using Models;

public interface IUploadServices
{
    public Task<List<UploadResultModel>> UploadDrawsFromCsvFilesAsync(IEnumerable<UploadFileModel> fileStreams);
}

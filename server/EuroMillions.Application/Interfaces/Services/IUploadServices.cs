namespace EuroMillions.Application.Interfaces.Services;

using Models;

public interface IUploadServices
{
    public Task<List<DrawFileModel>> UploadDrawsFromCsvFilesAsync(IEnumerable<UploadFileModel> fileStreams);
}

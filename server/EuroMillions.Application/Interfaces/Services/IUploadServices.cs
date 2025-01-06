namespace EuroMillions.Application.Interfaces.Services;

using Data.Models;

public interface IUploadServices
{
    public Task<List<DrawFileModel>> UploadDrawsFromCsvFilesAsync(IEnumerable<UploadFileModel> fileStreams);
}

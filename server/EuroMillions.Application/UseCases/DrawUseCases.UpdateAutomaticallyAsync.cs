using EuroMillions.Application.Models.Upload;

namespace EuroMillions.Application.UseCases;

public partial class DrawUseCases
{
    public async Task<UploadResultModel> UpdateAutomaticallyAsync()
    {
        List<DrawFileModel> drawFiles = await drawHistorySource.GetDrawFilesAsync();
        return await AddDrawsWithDeduplicationAsync(drawFiles);
    }
}

using EuroMillions.Application.Models.Upload;

using Microsoft.AspNetCore.Http;

namespace EuroMillions.Application.UseCases;

public partial class DrawUseCases
{
    public async Task<UploadResultModel> UploadDrawsFromCsvFilesAsync(IFormFileCollection uploadFileModels)
    {
        List<DrawFileModel> drawFileModels = uploadFileModels
            .Select(ufm =>
                new DrawFileModel {FileName = ufm.FileName, Draws = csvAdapter.ExtractEuroMillionDrawFromFile(ufm)}
            )
            .ToList();

        return await AddDrawsWithDeduplicationAsync(drawFileModels);
    }
}

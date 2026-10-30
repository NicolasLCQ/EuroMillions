using EuroMillions.Application.Models.Upload;

namespace EuroMillions.Application.UseCases;

public partial class DrawUseCases
{
    public async Task<UploadResultModel> UploadDrawsFromCsvFilesAsync(IReadOnlyCollection<UploadFileModel> uploadFileModels)
    {
        List<DrawFileModel> drawFileModels = uploadFileModels
            .Select(ufm =>
                new DrawFileModel {FileName = ufm.FileName, Draws = csvAdapter.ExtractEuroMillionDrawFromFile(ufm.Content)}
            )
            .ToList();

        return await AddDrawsWithDeduplicationAsync(drawFileModels);
    }
}

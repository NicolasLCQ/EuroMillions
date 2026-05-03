using EuroMillions.API.ViewModels;
using EuroMillions.Application.Models.Upload;

namespace EuroMillions.API.Mappers;

public static class UploadResultMapper
{
    public static UploadResponseViewModel ToUploadResponseViewModel(this UploadResultModel model) =>
        new UploadResponseViewModel
        {
            FileResults = model.FileResults.Select(f => f.ToUploadFileResponseViewModel()).ToList()
        };

    private static UploadFileResponseViewModel ToUploadFileResponseViewModel(this UploadFileResultModel model) =>
        new UploadFileResponseViewModel
        {
            FileName = model.FileName,
            AcceptedDraws = model.AcceptedDraws.Select(d => d.ToDrawResponseViewModel()).ToList(),
            RejectedDraws = model.RejectedDraws.Select(d => d.ToRejectedDrawResponseViewModel()).ToList()
        };
}

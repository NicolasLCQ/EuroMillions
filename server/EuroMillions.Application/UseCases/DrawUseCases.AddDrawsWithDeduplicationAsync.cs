using EuroMillions.Application.Extensions;
using EuroMillions.Application.Models;
using EuroMillions.Application.Models.Upload;

namespace EuroMillions.Application.UseCases;

public partial class DrawUseCases
{
    private async Task<UploadResultModel> AddDrawsWithDeduplicationAsync(List<DrawFileModel> drawFileModels)
    {
        HashSet<int> existingDrawNumbers = (await drawRepository.GetAllDrawsAsync())
            .Select(d => d.DrawInformation!.YearDrawNumber)
            .ToHashSet();

        HashSet<int> detectedDrawNumbers = [];
        List<Draw> drawsToAdd = [];
        List<UploadFileResultModel> uploadFileResults = [];

        foreach (DrawFileModel drawFileModel in drawFileModels)
        {
            List<Draw> acceptedDraws = [];
            List<RejectedDraw> rejectedDraws = [];

            foreach (Draw draw in drawFileModel.Draws)
            {
                if (existingDrawNumbers.Contains(draw.DrawInformation!.YearDrawNumber))
                {
                    rejectedDraws.Add(draw.ToRejectedDraw("Already Added"));
                    continue;
                }

                if (!detectedDrawNumbers.Add(draw.DrawInformation!.YearDrawNumber))
                {
                    rejectedDraws.Add(draw.ToRejectedDraw("Duplication"));
                    continue;
                }

                acceptedDraws.Add(draw);
                drawsToAdd.Add(draw);
            }

            uploadFileResults.Add(
                new UploadFileResultModel
                {
                    FileName = drawFileModel.FileName,
                    AcceptedDraws = acceptedDraws,
                    RejectedDraws = rejectedDraws
                }
            );
        }

        if (drawsToAdd.Any())
        {
            await drawRepository.AddDrawsAsync(drawsToAdd);
        }

        return new UploadResultModel {FileResults = uploadFileResults};
    }
}

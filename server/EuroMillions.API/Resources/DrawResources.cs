using EuroMillions.API.Mappers;
using EuroMillions.API.Models.ResponseModels;
using EuroMillions.Application.Interfaces.UseCases;
using EuroMillions.Application.Models.Upload;

namespace EuroMillions.API.Resources;

public class DrawResources(IDrawUseCases drawUseCases)
{
    public async Task<IResult> UploadFilesAsync(IFormFileCollection files)
    {
        if (!files.Any())
        {
            throw new ApplicationException("No files provided.");
        }

        HashSet<string> fileNames = [];

        if (files.Any(file => !fileNames.Add(file.FileName)))
        {
            throw new ApplicationException("Duplicate files are not accepted");
        }

        List<UploadResultModel> uploadResult = await drawUseCases.UploadDrawsFromCsvFilesAsync(files);

        return Results.Ok(uploadResult);
    }

    public async Task<IResult> GetLastDrawAsync()
    {
        GetLastDrawResponseModel? getLastDrawResponseModel = (await drawUseCases.GetLastDrawAsync())
            ?.ToGetLastDrawResponseModel();

        return Results.Ok(getLastDrawResponseModel);
    }
}

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
        DrawReponseModel? lastDraw = (await drawUseCases.GetLastDrawAsync())
            ?.ToDrawResponseModel();

        return Results.Ok(lastDraw);
    }

    public async Task<IResult> AreDrawsUpToDateAsync()
    {
        bool areDrawsUpToDate = await drawUseCases.AreUpToDate();
        AreUpToDateResponseModel response = new AreUpToDateResponseModel {AreUpToDate = areDrawsUpToDate};

        return Results.Ok(response);
    }

    public async Task<IResult> GetHistoryDownloadLinksAsync()
    {
        List<string> links = await drawUseCases.GetHistoryDownloadLinksAsync();
        HistoryDownloadLinksResponseModel response = new HistoryDownloadLinksResponseModel {Links = links};

        return Results.Ok(response);
    }
}

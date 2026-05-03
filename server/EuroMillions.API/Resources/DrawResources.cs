using EuroMillions.API.Mappers;
using EuroMillions.API.ViewModels;
using EuroMillions.Application.Interfaces.UseCases;
using EuroMillions.Application.Models;
using EuroMillions.Application.Models.Upload;

namespace EuroMillions.API.Resources;

public class DrawResources(IDrawUseCases drawUseCases)
{
    public async Task<IResult> UploadFilesAsync(IFormFileCollection files)
    {
        if (!files.Any())
        {
            throw new BadHttpRequestException("No files provided.");
        }

        HashSet<string> fileNames = [];

        if (files.Any(file => !fileNames.Add(file.FileName)))
        {
            throw new BadHttpRequestException("Duplicate files are not accepted");
        }

        UploadResultModel uploadResponse = await drawUseCases.UploadDrawsFromCsvFilesAsync(files);
        UploadResponseViewModel response = uploadResponse.ToUploadResponseViewModel();

        return Results.Ok(response);
    }

    public async Task<IResult> GetLastDrawAsync()
    {
        DrawResponseViewModel? lastDraw = (await drawUseCases.GetLastDrawAsync())
            ?.ToDrawResponseViewModel();

        return Results.Ok(lastDraw);
    }

    public async Task<IResult> GetNextDrawAsync()
    {
        DateTime nextDrawDate = await drawUseCases.GetNextDrawDateAsync();
        NextDrawResponseViewModel response = new NextDrawResponseViewModel {NextDrawDate = nextDrawDate};

        return Results.Ok(response);
    }

    public async Task<IResult> AreDrawsUpToDateAsync()
    {
        bool areDrawsUpToDate = await drawUseCases.AreUpToDateAsync();
        AreUpToDateResponseViewModel response = new AreUpToDateResponseViewModel {AreUpToDate = areDrawsUpToDate};

        return Results.Ok(response);
    }

    public async Task<IResult> UpdateAutomaticallyAsync()
    {
        UploadResponseViewModel uploadResponse = (await drawUseCases.UpdateAutomaticallyAsync()).ToUploadResponseViewModel();
        return Results.Ok(uploadResponse);
    }

    public async Task<IResult> GetAllAsync()
    {
        List<DrawSummaryModel> allDraws = await drawUseCases.GetAllAsync();
        List<DrawResponseViewModel> allDrawResponseViewModels = allDraws.Select(d => d.ToDrawResponseViewModel()).ToList();
        GetAllResponseViewModel getAllResponseViewModel = new GetAllResponseViewModel {Draws = allDrawResponseViewModels};
        return Results.Ok(getAllResponseViewModel);
    }
}

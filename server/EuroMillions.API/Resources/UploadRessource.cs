namespace EuroMillions.API.Resources;

using Application.Interfaces.Services;
using Application.Models;

using Mappers;

public class UploadRessource(IUploadServices uploadServices)
{
    public async Task<IResult> UploadFilesAsync(IFormFileCollection files)
    {
        if (!files.Any())
        {
            return Results.BadRequest("No files provided");
        }

        HashSet<string> fileNames = new();

        if (files.Any(file => fileNames.Add(file.FileName) == false))
        {
            return Results.BadRequest("Duplicate files are not accepted");
        }

        List<DrawFileModel> drawAddedDetails = await uploadServices.UploadDrawsFromCsvFilesAsync(files.Select(f => f.ToUploadFileModel()));

        return Results.Ok(drawAddedDetails);
    }
}

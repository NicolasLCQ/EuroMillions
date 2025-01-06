namespace EuroMillions.API.Resources;

using Application.Interfaces.Services;

using Data.Models;

using Mappers;

public class UploadRessource(IUploadServices uploadServices)
{
    public async Task<IResult> UploadFilesAsync(IFormFileCollection files)
    {
        if (!files.Any())
        {
            return Results.BadRequest("No files provided");
        }

        List<DrawFileModel> drawAddedDetails = await uploadServices.UploadDrawsFromCsvFilesAsync(files.Select(f => f.ToUploadFileModel()));

        return Results.Ok(drawAddedDetails);
    }
}

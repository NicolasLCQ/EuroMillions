namespace EuroMillions.API.Resources;

using Application.Interfaces;
using Application.Interfaces.Services;

public class UploadRessource(IDrawServices drawServices)
{
    public async Task<IResult> UploadFilesAsync(IFormFileCollection files)
    {
        if (!files.Any())
        {
            return Results.BadRequest("No files provided");
        }

        drawServices.AddDrawsFromCsvFiles(files.Select(f => f.OpenReadStream()));

        return Results.Ok(files.Select(file => file.FileName));
    }
}

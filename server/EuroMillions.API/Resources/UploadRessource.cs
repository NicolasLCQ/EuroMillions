namespace EuroMillions.API.Resources;

public class UploadRessource
{
    public async Task<IResult> UplaodFilesAsync(IFormFileCollection files)
    {
        if (!files.Any())
        {
            return Results.BadRequest("No files provided");
        }

        return Results.Ok(files.Select(file => file.FileName));
    }
}

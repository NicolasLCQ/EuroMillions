namespace EuroMillions.API.Resources;

using Application.Interfaces.Services;
using Application.Models;

using Mappers;

public class UploadRessource(IUploadServices uploadServices)
{
    //TODO : se renseigner sur les csv validators de csv helper surtout au niveau des messages d'erreurs a afficher
    public async Task<IResult> UploadFilesAsync(IFormFileCollection files)
    {
        if (!files.Any())
        {
            //TODO : throw error instead ? and delegate return to Error Hnadlers only
            throw new ApplicationException("No files provided.");
            return Results.BadRequest("No files provided");
        }

        HashSet<string> fileNames = new();

        if (files.Any(file => fileNames.Add(file.FileName) == false))
        {
            return Results.BadRequest("Duplicate files are not accepted");
        }

        List<UploadResultModel> uploadResult = await uploadServices.UploadDrawsFromCsvFilesAsync(files.Select(f => f.ToUploadFileModel()));
        return Results.Ok(uploadResult);
    }
}

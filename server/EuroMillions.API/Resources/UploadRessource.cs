using EuroMillions.Application.Interfaces.Services;
using EuroMillions.Application.Models;

namespace EuroMillions.API.Resources;

public class UploadRessource(IUploadServices uploadServices)
{
    //TODO : se renseigner sur les csv validators de csv helper surtout au niveau des messages d'erreurs a afficher
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

        List<UploadResultModel> uploadResult = await uploadServices.UploadDrawsFromCsvFilesAsync(files);

        return Results.Ok(uploadResult);
    }
}

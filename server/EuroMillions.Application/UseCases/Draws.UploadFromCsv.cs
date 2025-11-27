using EuroMillions.Application.Models;
using EuroMillions.Application.Models.Upload;

using Microsoft.AspNetCore.Http;

namespace EuroMillions.Application.UseCases;

public partial class Draws
{
    public async Task<List<UploadResultModel>> UploadDrawsFromCsvFilesAsync(IFormFileCollection uploadFileModels)
    {
        List<DrawFileModel> drawFileModels = uploadFileModels.Select(ufm =>
                {
                    try
                    {
                        List<Draw> draws = csvAdapter.ExtractEuroMillionDrawFromFileAsStream(ufm).ToList();

                        return new DrawFileModel {FileName = ufm.FileName, Draws = draws};
                    }
                    catch (Exception e)
                    {
                        //todo: ajouter le nom du fichier qui ne peut pas etre lu : ufm.FileName

                        throw new ApplicationException(e.Message);
                    }
                }
            )
            .ToList();

        return await drawRepository.AddDrawsFromDrawFileModelsAsync(drawFileModels);
    }
}

namespace EuroMillions.Application.Services;

using Interfaces.Infrastructure.Adapters;
using Interfaces.Infrastructure.Repositories;
using Interfaces.Services;

using Models;

public class UploadServices(ICsvAdapter csvAdapter, IDrawRepository drawRepository) : IUploadServices
{
    public async Task<List<UploadResultModel>> UploadDrawsFromCsvFilesAsync(IEnumerable<UploadFileModel> uploadFileModels)
    {
        List<DrawFileModel> drawFileModels = uploadFileModels.Select(ufm =>
            {
                try
                {
                    List<Draw> draws = csvAdapter.ExtractEuroMillionDrawFromFileAsStream(ufm.FileSream).ToList();

                    return new DrawFileModel {FileName = ufm.FileName, Draws = draws};
                }
                catch (Exception e)
                {
                    //ajouter le nom du fichier qui ne peut pas etre lu : ufm.FileName

                    throw new ApplicationException(e.Message);
                }
            })
            .ToList();

        return await drawRepository.AddDrawsFromDrawFileModelsAsync(drawFileModels);
    }
}

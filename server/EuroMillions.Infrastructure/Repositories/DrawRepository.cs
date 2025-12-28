using EuroMillions.Application.Interfaces.Infrastructure.Repositories;
using EuroMillions.Application.Models;
using EuroMillions.Application.Models.Upload;
using EuroMillions.Infrastructure.Context;
using EuroMillions.Infrastructure.Entities;
using EuroMillions.Infrastructure.Mappers.EntityMappers;

namespace EuroMillions.Infrastructure.Repositories;

using static T_DrawMapper;

public class DrawRepository(EuroMillionsDbContext dbContext) : IDrawRepository
{
    public async Task<List<UploadResultModel>> AddDrawsFromDrawFileModelsAsync(List<DrawFileModel> drawFileModels)
    {
        //todo: faire un get all et un add✅
        //todo: remonter la logique de old et new dans le service.
        //todo: gerer les problemes métier au niveau du service.
        //todo: ajouter une fonction addDraws pour les draws
        //todo: virer l'objet UploadResultModel de cette couche !! seul draw à l'aire d'etre util !!
        List<UploadResultModel> result = drawFileModels.Select(dfm =>
                {
                    List<T_DRAW> existingDraws = dbContext.T_DRAWs.ToList();

                    List<Draw> newDraws = dfm.Draws
                        .Where(drawFromFile => !existingDraws
                            .Select(existingDraw => existingDraw.YEAR_DRAW_NUMBER)
                            .Contains(drawFromFile.YearDrawNumber)
                        )
                        .ToList();

                    List<Draw> oldDraws = dfm.Draws
                        .Where(drawFromFile => existingDraws
                            .Select(existingDraw => existingDraw.YEAR_DRAW_NUMBER)
                            .Contains(drawFromFile.YearDrawNumber)
                        )
                        .ToList();

                    return new UploadResultModel
                    {
                        FileName = dfm.FileName,
                        AcceptedDraws = newDraws,
                        RejectedDraws = oldDraws
                    };
                }
            )
            .ToList();

        List<T_DRAW> drawsToAdd = result.SelectMany(r => r.AcceptedDraws).Select(d => d.ToT_DRAWEntity()).ToList();
        dbContext.T_DRAWs.AddRange(drawsToAdd);
        await dbContext.SaveChangesAsync();

        return result;
    }

    public async Task<List<Draw>> GetAllDrawsAsync() => dbContext.T_DRAWs.Select(entity => entity.ToDrawModel()).ToList();

    public async Task AddDrawsAsync(List<Draw> draws)
    {
        dbContext.T_DRAWs.AddRange(draws.Select(d => d.ToT_DRAWEntity()));
        await dbContext.SaveChangesAsync();
    }

    public async Task<Draw?> GetLastDrawAsync() =>
        dbContext.T_DRAWs
            .OrderByDescending(d => d.DRAW_DATE)
            .FirstOrDefault()
            ?.ToDrawModel();
}

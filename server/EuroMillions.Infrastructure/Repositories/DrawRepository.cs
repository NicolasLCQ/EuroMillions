using EuroMillions.Application.Interfaces.Infrastructure.Repositories;
using EuroMillions.Application.Models;
using EuroMillions.Infrastructure.Context;
using EuroMillions.Infrastructure.Entities;
using EuroMillions.Infrastructure.Mappers.EntityMappers;

namespace EuroMillions.Infrastructure.Repositories;

using static T_DrawMapper;

public class DrawRepository(EuroMillionsDbContext dbContext) : IDrawRepository
{
    public async Task<List<UploadResultModel>> AddDrawsFromDrawFileModelsAsync(List<DrawFileModel> drawFileModels)
    {
        List<UploadResultModel> result = drawFileModels.Select(dfm =>
                {
                    List<T_DRAW> existingDraws = dbContext.T_DRAWs.ToList();

                    List<Draw> newDraws = dfm.Draws
                        .Where(drawFromFile => !existingDraws.Select(existingDraw => existingDraw.YEAR_DRAW_NUMBER)
                            .Contains(drawFromFile.YearDrawNumber)
                        )
                        .ToList();

                    List<Draw> oldDraws = dfm.Draws
                        .Where(drawFromFile => existingDraws.Select(existingDraw => existingDraw.YEAR_DRAW_NUMBER)
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

        List<T_DRAW> drawsToAdd = result.SelectMany(r => r.AcceptedDraws).Select(ad => FromModel(ad)).ToList();
        dbContext.T_DRAWs.AddRange(drawsToAdd);
        await dbContext.SaveChangesAsync();

        return result;
    }
}

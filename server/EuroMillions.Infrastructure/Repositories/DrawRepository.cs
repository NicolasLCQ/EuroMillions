using EuroMillions.Application.Interfaces.Infrastructure.Repositories;
using EuroMillions.Application.Models;
using EuroMillions.Application.Models.Upload;
using EuroMillions.Infrastructure.Context;
using EuroMillions.Infrastructure.Entities;
using EuroMillions.Infrastructure.Extensions;
using EuroMillions.Infrastructure.Mappers.EntityMappers;

using Microsoft.EntityFrameworkCore;

namespace EuroMillions.Infrastructure.Repositories;

using static T_DrawMapper;

public class DrawRepository(EuroMillionsDbContext dbContext) : IDrawRepository
{
    public async Task<List<UploadResultSimpleModel>> AddDrawsFromDrawFileModelsAsync(List<DrawFileModel> drawFileModels)
    {
        //todo: faire un get all et un add✅
        //todo: remonter la logique de old et new dans le service.
        //todo: gerer les problemes métier au niveau du service.
        //todo: ajouter une fonction addDraws pour les draws
        //todo: virer l'objet UploadResultModel de cette couche !! seul draw à l'aire d'etre util !!
        //todo: utiliser un dataset pour pas avoir de double dans ce que l'on ajoute :: pas ajouter ce qui existe deja et pas ajouter en double
        List<UploadResultSimpleModel> result = drawFileModels.Select(dfm =>
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

                    return new UploadResultSimpleModel
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

    public async Task<List<Draw>> GetAllDrawsAsync() => await dbContext.T_DRAWs
        .Select(entity => entity.ToDrawModel())
        .AsNoTracking()
        .ToListAsync();

    public async Task AddDrawsAsync(List<Draw> draws)
    {
        dbContext.T_DRAWs.AddRange(draws.Select(d => d.ToT_DRAWEntity()));
        await dbContext.SaveChangesAsync();
    }

    public async Task<Draw?> GetLastDrawAsync() =>
        await dbContext.T_DRAWs
            .OrderByDescending(d => d.DRAW_DATE)
            .AsNoTracking()
            .Select(d => d.ToDrawModel())
            .FirstOrDefaultAsync();

    public async Task<bool> AreDrawsUpToDateAsync()
    {
        T_DRAW? lastestDrawUploaded = await dbContext
            .T_DRAWs
            .AsNoTracking()
            .OrderByDescending(d => d.DRAW_DATE)
            .FirstOrDefaultAsync();

        if (lastestDrawUploaded == null)
        {
            return false;
        }

        List<DayOfWeek> drawDays = [DayOfWeek.Tuesday, DayOfWeek.Friday];

        List<DayOfWeek> drawPublicationDay = drawDays
            .Select(d => d + 1)
            .ToList();

        DateTime lastDrawPublicationDate = Enumerable.Range(0, 7)
            .Select(i => DateTime.Today.AddDays(-i))
            .First(d => drawPublicationDay.Contains(d.DayOfWeek));

        return lastestDrawUploaded.GetPublicationDate() == lastDrawPublicationDate;
    }
}

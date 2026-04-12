using EuroMillions.Application.Interfaces.Infrastructure.Repositories;
using EuroMillions.Application.Models;
using EuroMillions.Infrastructure.Context;
using EuroMillions.Infrastructure.Entities;
using EuroMillions.Infrastructure.Extensions;
using EuroMillions.Infrastructure.Mappers.EntityMappers;

using Microsoft.EntityFrameworkCore;

namespace EuroMillions.Infrastructure.Repositories;

using static T_DrawMapper;

public class DrawRepository(EuroMillionsDbContext dbContext) : IDrawRepository
{
    public async Task<List<Draw>> GetAllDrawsAsync() => await dbContext.T_DRAWs
        .Select(entity => entity.ToDrawModel())
        .AsNoTracking()
        .ToListAsync();

    public async Task AddDrawsAsync(List<Draw> draws)
    {
        dbContext.T_DRAWs.AddRange(draws.Select(d => d.ToDRAWEntity()));
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

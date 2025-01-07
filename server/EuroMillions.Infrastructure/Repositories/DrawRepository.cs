namespace EuroMillions.Infrastructure.Repositories;

using Application.Interfaces.Infrastructure.Repositories;
using Application.Models;

using Context;

using Entities;

using Microsoft.EntityFrameworkCore;

using static Mappers.EntityMappers.T_DrawMapper;

public class DrawRepository(EuroMillionsDbContext dbContext) : IDrawRepository
{
    public async Task<IList<Draw>> FilterNewDrawsAsync(IEnumerable<Draw> draws)
    {
        IEnumerable<int> oldDrawYearDrawNumbers = await dbContext.T_DRAWs
            .AsNoTracking()
            .Select(d => d.YEAR_DRAW_NUMBER)
            .ToListAsync();

        return draws.Where(d => !oldDrawYearDrawNumbers.Contains(d.YearDrawNumber)).ToList();
    }

    public async Task AddDrawsAsync(IEnumerable<Draw> draws)
    {
        IList<T_DRAW> drawsToAdd = draws.Select(d => FromModel(d)).ToList();

        dbContext.T_DRAWs.AddRange(drawsToAdd);
        await dbContext.SaveChangesAsync();
    }
}

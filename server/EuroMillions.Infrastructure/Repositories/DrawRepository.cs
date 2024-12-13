namespace EuroMillions.Infrastructure.Repositories;

using Application.Interfaces.Infrastructure.Repositories;

using Context;

using Data.Models;

using Entities;

using Mappers.EntityMappers;

using Microsoft.EntityFrameworkCore;

public class DrawRepository(EuroMillionsDbContext dbContext) : IDrawRepository
{
    //peut etre optimisé en utilisant les dates pour filtrer ce que l'on compare
    public async Task<IEnumerable<Draw>> FilterNewDrawsAsync(IEnumerable<Draw> draws)
    {
        IEnumerable<int> oldDrawYearDrawNumbers = await dbContext.T_DRAWs
            .Select(d => d.YEAR_DRAW_NUMBER)
            .ToListAsync();

        return draws.Where(d => !oldDrawYearDrawNumbers.Contains(d.YearDrawNumber)).ToList();
    }

    public async Task<int> AddDrawsAsync(IEnumerable<Draw> draws)
    {
        IEnumerable<Draw> enumeratedDraws = draws.ToList();

        await dbContext.T_DRAWs.AddRangeAsync(enumeratedDraws.Select(d => new T_DRAW().FromModel(d)));
        await dbContext.SaveChangesAsync();

        return enumeratedDraws.Count();
    }
}

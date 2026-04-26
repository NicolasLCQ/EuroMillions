using EuroMillions.Application.Interfaces.Infrastructure.Repositories;
using EuroMillions.Application.Models;
using EuroMillions.Infrastructure.Context;
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
        dbContext.T_DRAWs.AddRange(draws.Select(d => d.ToDrawEntity()));
        await dbContext.SaveChangesAsync();
    }

    public async Task<Draw?> GetLastDrawAsync() =>
        await dbContext.T_DRAWs
            .OrderByDescending(d => d.DRAW_DATE)
            .AsNoTracking()
            .Select(d => d.ToDrawModel())
            .FirstOrDefaultAsync();
}

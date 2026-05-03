using EuroMillions.Application.Interfaces.Infrastructure.Repositories;
using EuroMillions.Application.Models;
using EuroMillions.Infrastructure.Context;
using EuroMillions.Infrastructure.Mappers.EntityMappers;

using Microsoft.EntityFrameworkCore;

namespace EuroMillions.Infrastructure.Repositories;

using static T_DrawMapper;

public class DrawRepository(EuroMillionsDbContext dbContext) : IDrawRepository
{
    public async Task<List<DrawSummaryModel>> GetAllDrawsAsync() => (await dbContext.T_DRAWs
            .Include(draw => draw.T_DRAW_INFORMATION)
            .AsNoTracking()
            .ToListAsync())
        .Select(entity => entity.ToDrawSummaryModel())
        .ToList();

    public async Task AddDrawsAsync(List<Draw> draws)
    {
        dbContext.T_DRAWs.AddRange(draws.Select(d => d.ToDrawEntity()));
        await dbContext.SaveChangesAsync();
    }

    public async Task<DrawSummaryModel?> GetLastDrawAsync() =>
        (await dbContext.T_DRAWs
            .Include(draw => draw.T_DRAW_INFORMATION)
            .OrderByDescending(d => d.T_DRAW_INFORMATION!.DRAW_DATE)
            .AsNoTracking()
            .FirstOrDefaultAsync())
        ?.ToDrawSummaryModel();
}

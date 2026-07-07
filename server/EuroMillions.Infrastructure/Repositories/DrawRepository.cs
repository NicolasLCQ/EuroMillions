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
            .Include(draw => draw.T_DRAW_ADDITIONAL_GAME)
            .Include(draw => draw.T_DRAW_WINNER)
            .AsNoTracking()
            .ToListAsync())
        .Select(entity => entity.ToDrawSummaryModel())
        .ToList();

    public async Task AddDrawsAsync(List<Draw> draws)
    {
        dbContext.T_DRAWs.AddRange(draws.Select(d => d.ToDrawEntity()));
        await dbContext.SaveChangesAsync();
    }

    public async Task<Dictionary<int, int>> GetAllBallsNbTimePickedAsync()
    {
        var draws = await dbContext.T_DRAWs
            .AsNoTracking()
            .Select(draw => new
                {
                    draw.BALL_ONE,
                    draw.BALL_TWO,
                    draw.BALL_THREE,
                    draw.BALL_FOUR,
                    draw.BALL_FIVE
                }
            )
            .ToListAsync();

        Dictionary<int, int> ballCounts = Enumerable.Range(1, 50).ToDictionary(ball => ball, _ => 0);

        foreach (var draw in draws)
        {
            IncrementCount(ballCounts, draw.BALL_ONE);
            IncrementCount(ballCounts, draw.BALL_TWO);
            IncrementCount(ballCounts, draw.BALL_THREE);
            IncrementCount(ballCounts, draw.BALL_FOUR);
            IncrementCount(ballCounts, draw.BALL_FIVE);
        }

        return ballCounts;
    }

    public async Task<Dictionary<int, int>> GetAllStarsNbTimePickedAsync()
    {
        var draws = await dbContext.T_DRAWs
            .AsNoTracking()
            .Select(draw => new
                {
                    draw.STAR_ONE,
                    draw.STAR_TWO
                }
            )
            .ToListAsync();

        Dictionary<int, int> starCounts = Enumerable.Range(1, 12).ToDictionary(star => star, _ => 0);

        foreach (var draw in draws)
        {
            IncrementCount(starCounts, draw.STAR_ONE);
            IncrementCount(starCounts, draw.STAR_TWO);
        }

        return starCounts;
    }

    private static void IncrementCount(Dictionary<int, int> counts, int value)
    {
        if (counts.ContainsKey(value))
        {
            counts[value]++;
        }
    }

    public async Task<DrawSummaryModel?> GetLastDrawAsync() =>
        (await dbContext.T_DRAWs
            .Include(draw => draw.T_DRAW_INFORMATION)
            .Include(draw => draw.T_DRAW_ADDITIONAL_GAME)
            .Include(draw => draw.T_DRAW_WINNER)
            .OrderByDescending(d => d.T_DRAW_INFORMATION!.DRAW_DATE)
            .AsNoTracking()
            .FirstOrDefaultAsync())
        ?.ToDrawSummaryModel();
}

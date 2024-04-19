using EuroMillions.API.Context;
using EuroMillions.API.Entities;
using EuroMillions.Application.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EuroMillions.Gateway.Repositories;

public class DrawsRepository(EuroMillionsStudyDbContext currentContext): IDrawsRepository
{
    public async Task<List<t_Draw?>> GetDraws()
    {
        return await currentContext.t_Draws.ToListAsync();
    }
    
    public async Task<t_Draw?> GetDrawById(int id)
    {
        return await currentContext.t_Draws.FirstOrDefaultAsync(draw => draw.Id == id);
    }
    
    public async Task AddDraws(IEnumerable<t_Draw> draws)
    {
        await currentContext.t_Draws.AddRangeAsync(draws);
        await currentContext.SaveChangesAsync();
    }
}
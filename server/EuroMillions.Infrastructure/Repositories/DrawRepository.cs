namespace EuroMillions.Infrastructure.Repositories;

using Application.Interfaces.Infrastructure.Repositories;

using Context;

using Data.Models;

using Entities;

using Mappers.EntityMappers;

public class DrawRepository(EuroMillionsDbContext dbContext) : IDrawRepository
{
    public async Task<int> AddDrawsAsync(IEnumerable<Draw> draws)
    {
        await dbContext.T_DRAWs.AddRangeAsync(draws.Select(d => new T_DRAW().FromModel(d)));
        await dbContext.SaveChangesAsync();
        return draws.Count();
    }
}

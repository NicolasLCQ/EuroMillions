namespace EuroMillions.Infrastructure.Repositories;

using Application.Interfaces.Infrastructure.Repositories;

using Context;

using Data.Models;

using Entities;

using Mappers.EntityMappers;

public class DrawRepository(EuroMillionsDbContext dbContext) : IDrawRepository
{
    //TODO: ajouter verification de ne pas ajouter des doublons -> piste possible le year draw number devrait etre unique
    public async Task<int> AddDrawsAsync(IEnumerable<Draw> draws)
    {
        await dbContext.T_DRAWs.AddRangeAsync(draws.Select(d => new T_DRAW().FromModel(d)));
        await dbContext.SaveChangesAsync();
        return draws.Count();
    }
}

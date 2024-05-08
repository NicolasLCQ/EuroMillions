using EuroMillions.API.Entities;
using EuroMillions.Application.Contracts.Repositories;

namespace EuroMillions.Application.Services;

public class DrawsServices(IDrawsRepository drawsRepository)
{
    public async Task<IEnumerable<t_Draw?>> GetDraws()
    {
        return await drawsRepository.GetDraws();
    }
    
    public async Task AddDraws(IEnumerable<t_Draw> draws)
    {
        if(draws == null)
        {
            throw new ArgumentNullException(nameof(draws));
        }
        
        await drawsRepository.AddDraws(draws.Where(d => GetDrawById(d.Id) == null));
    }
    
    public async Task<t_Draw?> GetDrawById(int id)
    {
        return await drawsRepository.GetDrawById(id);
    }
}
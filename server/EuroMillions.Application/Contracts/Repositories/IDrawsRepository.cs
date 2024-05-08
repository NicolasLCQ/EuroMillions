using EuroMillions.API.Entities;

namespace EuroMillions.Application.Contracts.Repositories;

public interface IDrawsRepository
{
    public Task<List<t_Draw?>> GetDraws();
    public Task<t_Draw?> GetDrawById(int id);
    public Task AddDraws(IEnumerable<t_Draw> draws);

}
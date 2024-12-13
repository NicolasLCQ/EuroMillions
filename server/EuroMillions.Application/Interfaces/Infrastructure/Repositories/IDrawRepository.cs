namespace EuroMillions.Application.Interfaces.Infrastructure.Repositories;

using Data.Models;

public interface IDrawRepository
{
    public Task<int> AddDrawsAsync(IEnumerable<Draw> draws);
    public Task<IEnumerable<Draw>> FilterNewDrawsAsync(IEnumerable<Draw> draws);
}

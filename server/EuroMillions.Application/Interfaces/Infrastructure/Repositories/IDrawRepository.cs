namespace EuroMillions.Application.Interfaces.Infrastructure.Repositories;

using Data.Models;

public interface IDrawRepository
{
    public Task AddDrawsAsync(IEnumerable<Draw> draws);
    public Task<IList<Draw>> FilterNewDrawsAsync(IEnumerable<Draw> draws);
}

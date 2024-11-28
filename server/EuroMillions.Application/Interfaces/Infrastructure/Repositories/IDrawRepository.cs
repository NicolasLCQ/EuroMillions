namespace EuroMillions.Application.Interfaces.Infrastructure.Repositories;

using Data.Models;

public interface IDrawRepository
{
    public Task<int> AddDrawsAsync(IEnumerable<Draw> draws);
}

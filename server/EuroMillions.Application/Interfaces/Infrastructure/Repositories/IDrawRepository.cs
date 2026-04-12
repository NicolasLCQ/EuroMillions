using EuroMillions.Application.Models;

namespace EuroMillions.Application.Interfaces.Infrastructure.Repositories;

public interface IDrawRepository
{
    Task<List<Draw>> GetAllDrawsAsync();
    Task<Draw?> GetLastDrawAsync();
    Task AddDrawsAsync(List<Draw> draws);
    Task<bool> AreDrawsUpToDateAsync();
}

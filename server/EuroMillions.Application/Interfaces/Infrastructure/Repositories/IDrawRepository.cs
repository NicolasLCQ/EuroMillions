using EuroMillions.Application.Models;

namespace EuroMillions.Application.Interfaces.Infrastructure.Repositories;

public interface IDrawRepository
{
    Task<List<DrawSummaryModel>> GetAllDrawsAsync();
    Task<DrawSummaryModel?> GetLastDrawAsync();
    Task AddDrawsAsync(List<Draw> draws);
}

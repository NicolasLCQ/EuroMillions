using EuroMillions.Application.Models;

namespace EuroMillions.Application.Interfaces.Infrastructure.Repositories;

public interface IDrawRepository
{
    Task<List<DrawSummaryModel>> GetAllDrawsAsync();
    Task<DrawSummaryModel?> GetLastDrawAsync();
    Task<int> GetBallNbTimePickedAsync(int ballNumber);
    Task<int> GetStarNbTimePickedAsync(int starNumber);
    Task<Dictionary<int, int>> GetAllBallsNbTimePickedAsync();
    Task<Dictionary<int, int>> GetAllStarsNbTimePickedAsync();
    Task AddDrawsAsync(List<Draw> draws);
}

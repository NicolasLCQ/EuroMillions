using EuroMillions.Application.Extensions;
using EuroMillions.Application.Mappers;
using EuroMillions.Application.Models;

namespace EuroMillions.Application.UseCases;

public partial class DrawUseCases
{
    public async Task<DrawItemsStatisticsModel> GetStatisticsAsync()
    {
        List<MinimalDrawModel> draws = await drawRepository.GetMinimalDrawsAsync();
        (BallDictionary ballCounts, StarDictionary starCounts) = draws.CalculateNbTimesDraw();

        return new DrawItemsStatisticsModel
        {
            Balls = ballCounts
                .OrderBy(entry => (int)entry.Key)
                .Select(entry => entry.ToDrawItemStatisticsModel())
                .ToList(),
            Stars = starCounts
                .OrderBy(entry => (int)entry.Key)
                .Select(entry => entry.ToDrawItemStatisticsModel())
                .ToList()
        };
    }
}

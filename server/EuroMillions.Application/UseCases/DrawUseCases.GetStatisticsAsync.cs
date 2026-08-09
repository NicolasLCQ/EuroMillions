using EuroMillions.Application.Extensions;
using EuroMillions.Application.Models;

namespace EuroMillions.Application.UseCases;

public partial class DrawUseCases
{
    public async Task<DrawItemsStatisticsModel> GetStatisticsAsync()
    {
        List<MinimalDrawModel> draws = await drawRepository.GetMinimalDrawsAsync();
        (BallDictionary ballCounts, StarDictionary starCounts) = draws.CalculateNbTimesDraw();

        (BallDictionary ballNbDrawsSinceLastOccurrence, StarDictionary starNbDrawsSinceLastOccurrence)
            = draws.CalculateNbDrawsSinceLastOccurrence();

        return new DrawItemsStatisticsModel
        {
            Stars = Enumerable.Range(1, 12)
                .Select(s => new StarStatisticsModel
                    {
                        Star = s,
                        NbTimesDraw = starCounts[s],
                        NbDrawsSinceLastOccurrence = starNbDrawsSinceLastOccurrence[s]
                    }
                )
                .ToList(),
            Balls = Enumerable.Range(1, 50)
                .Select(b => new BallStatisticsModel
                    {
                        Ball = b,
                        NbTimesDraw = ballCounts[b],
                        NbDrawsSinceLastOccurrence = ballNbDrawsSinceLastOccurrence[b]
                    }
                )
                .ToList()
        };
    }
}

using EuroMillions.Application.Extensions;
using EuroMillions.Application.Models;

namespace EuroMillions.Application.UseCases;

public partial class DrawUseCases
{
    public async Task<DrawItemsStatisticsModel> GetStatisticsAsync()
    {
        List<MinimalDrawModel> draws = await drawRepository.GetMinimalDrawsAsync();
        (BallDictionary<int> ballCounts, StarDictionary<int> starCounts) = draws.CalculateNbTimesDraw();

        (BallDictionary<int> ballNbDrawsSinceLastOccurrence, StarDictionary<int> starNbDrawsSinceLastOccurrence)
            = draws.CalculateNbDrawsSinceLastOccurrence();
        (BallDictionary<double> ballAverageNbDrawsBetweenOccurrences,
                StarDictionary<double> starAverageNbDrawsBetweenOccurrences)
            = draws.CalculateAverageNbDrawsBetweenOccurrences();

        return new DrawItemsStatisticsModel
        {
            Stars = Enumerable.Range(Star.MinValue, Star.ValueCount)
                .Select(s => new StarStatisticsModel
                    {
                        Star = s,
                        NbTimesDraw = starCounts[s],
                        NbDrawsSinceLastOccurrence = starNbDrawsSinceLastOccurrence[s],
                        AverageNbDrawsBetweenOccurrences = starAverageNbDrawsBetweenOccurrences[s]
                    }
                )
                .ToList(),
            Balls = Enumerable.Range(Ball.MinValue, Ball.ValueCount)
                .Select(b => new BallStatisticsModel
                    {
                        Ball = b,
                        NbTimesDraw = ballCounts[b],
                        NbDrawsSinceLastOccurrence = ballNbDrawsSinceLastOccurrence[b],
                        AverageNbDrawsBetweenOccurrences = ballAverageNbDrawsBetweenOccurrences[b]
                    }
                )
                .ToList()
        };
    }
}

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
        (BallDictionary<int> ballMinimumNbDrawsBetweenOccurrences,
                StarDictionary<int> starMinimumNbDrawsBetweenOccurrences)
            = draws.CalculateMinimumNbDrawsBetweenOccurrences();
        (BallDictionary<int> ballMaximumNbDrawsBetweenOccurrences,
                StarDictionary<int> starMaximumNbDrawsBetweenOccurrences)
            = draws.CalculateMaximumNbDrawsBetweenOccurrences();
        (BallDictionary<double> ballVarianceNbDrawsBetweenOccurrences,
                StarDictionary<double> starVarianceNbDrawsBetweenOccurrences)
            = draws.CalculateVarianceNbDrawsBetweenOccurrences();
        (BallDictionary<double> ballStandardDeviationNbDrawsBetweenOccurrences,
                StarDictionary<double> starStandardDeviationNbDrawsBetweenOccurrences)
            = draws.CalculateStandardDeviationNbDrawsBetweenOccurrences();

        return new DrawItemsStatisticsModel
        {
            Stars = Enumerable.Range(Star.MinValue, Star.ValueCount)
                .Select(s => new StarStatisticsModel
                    {
                        Star = s,
                        NbTimesDraw = starCounts[s],
                        NbDrawsSinceLastOccurrence = starNbDrawsSinceLastOccurrence[s],
                        AverageNbDrawsBetweenOccurrences = starAverageNbDrawsBetweenOccurrences[s],
                        MinimumNbDrawsBetweenOccurrences = starMinimumNbDrawsBetweenOccurrences[s],
                        MaximumNbDrawsBetweenOccurrences = starMaximumNbDrawsBetweenOccurrences[s],
                        VarianceNbDrawsBetweenOccurrences = starVarianceNbDrawsBetweenOccurrences[s],
                        StandardDeviationNbDrawsBetweenOccurrences
                            = starStandardDeviationNbDrawsBetweenOccurrences[s]
                    }
                )
                .ToList(),
            Balls = Enumerable.Range(Ball.MinValue, Ball.ValueCount)
                .Select(b => new BallStatisticsModel
                    {
                        Ball = b,
                        NbTimesDraw = ballCounts[b],
                        NbDrawsSinceLastOccurrence = ballNbDrawsSinceLastOccurrence[b],
                        AverageNbDrawsBetweenOccurrences = ballAverageNbDrawsBetweenOccurrences[b],
                        MinimumNbDrawsBetweenOccurrences = ballMinimumNbDrawsBetweenOccurrences[b],
                        MaximumNbDrawsBetweenOccurrences = ballMaximumNbDrawsBetweenOccurrences[b],
                        VarianceNbDrawsBetweenOccurrences = ballVarianceNbDrawsBetweenOccurrences[b],
                        StandardDeviationNbDrawsBetweenOccurrences
                            = ballStandardDeviationNbDrawsBetweenOccurrences[b]
                    }
                )
                .ToList()
        };
    }
}

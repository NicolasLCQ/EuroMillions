using EuroMillions.Application.Extensions;
using EuroMillions.Application.Models;

namespace EuroMillions.Application.UseCases;

public partial class DrawUseCases
{
    public async Task<DrawItemsStatisticsModel> GetStatisticsAsync()
    {
        List<MinimalDrawModel> draws = await drawRepository.GetMinimalDrawsAsync();
        (BallDictionary<OccurrenceIndexes> ballOccurrenceIndexes,
                StarDictionary<OccurrenceIndexes> starOccurrenceIndexes)
            = draws.CalculateOccurrenceIndexes();

        return new DrawItemsStatisticsModel
        {
            Stars = Enumerable.Range(Star.MinValue, Star.ValueCount)
                .Select(s =>
                    {
                        OccurrenceIndexes indexes = starOccurrenceIndexes[s];
                        OccurrenceGaps gaps = indexes.CalculateNbDrawsBetweenOccurrences();
                        (double average, double variance, double standardDeviation)
                            = gaps.CalculateAverageVarianceAndStandardDeviationNbDrawsBetweenOccurrences();

                        return new StarStatisticsModel
                        {
                            Star = s,
                            NbTimesDraw = indexes.Count,
                            NbDrawsSinceLastOccurrence = indexes.CalculateNbDrawsSinceLastOccurrence(draws.Count),
                            AverageNbDrawsBetweenOccurrences = average,
                            MinimumNbDrawsBetweenOccurrences = gaps.CalculateMinimumNbDrawsBetweenOccurrences(),
                            MaximumNbDrawsBetweenOccurrences = gaps.CalculateMaximumNbDrawsBetweenOccurrences(),
                            VarianceNbDrawsBetweenOccurrences = variance,
                            StandardDeviationNbDrawsBetweenOccurrences = standardDeviation
                        };
                    }
                )
                .ToList(),
            Balls = Enumerable.Range(Ball.MinValue, Ball.ValueCount)
                .Select(b =>
                    {
                        OccurrenceIndexes indexes = ballOccurrenceIndexes[b];
                        OccurrenceGaps gaps = indexes.CalculateNbDrawsBetweenOccurrences();
                        (double average, double variance, double standardDeviation)
                            = gaps.CalculateAverageVarianceAndStandardDeviationNbDrawsBetweenOccurrences();

                        return new BallStatisticsModel
                        {
                            Ball = b,
                            NbTimesDraw = indexes.Count,
                            NbDrawsSinceLastOccurrence = indexes.CalculateNbDrawsSinceLastOccurrence(draws.Count),
                            AverageNbDrawsBetweenOccurrences = average,
                            MinimumNbDrawsBetweenOccurrences = gaps.CalculateMinimumNbDrawsBetweenOccurrences(),
                            MaximumNbDrawsBetweenOccurrences = gaps.CalculateMaximumNbDrawsBetweenOccurrences(),
                            VarianceNbDrawsBetweenOccurrences = variance,
                            StandardDeviationNbDrawsBetweenOccurrences = standardDeviation
                        };
                    }
                )
                .ToList()
        };
    }
}

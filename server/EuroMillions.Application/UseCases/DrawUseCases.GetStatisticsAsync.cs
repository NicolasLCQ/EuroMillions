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
                        int[] gaps = indexes.CalculateNbDrawsBetweenOccurrences();
                        double average = indexes.CalculateAverageNbDrawsBetweenOccurrences(gaps);
                        double variance = indexes.CalculateVarianceNbDrawsBetweenOccurrences(gaps, average);

                        return new StarStatisticsModel
                        {
                            Star = s,
                            NbTimesDraw = indexes.Count,
                            NbDrawsSinceLastOccurrence = indexes.CalculateNbDrawsSinceLastOccurrence(draws.Count),
                            AverageNbDrawsBetweenOccurrences = average,
                            MinimumNbDrawsBetweenOccurrences
                                = indexes.CalculateMinimumNbDrawsBetweenOccurrences(gaps),
                            MaximumNbDrawsBetweenOccurrences
                                = indexes.CalculateMaximumNbDrawsBetweenOccurrences(gaps),
                            VarianceNbDrawsBetweenOccurrences = variance,
                            StandardDeviationNbDrawsBetweenOccurrences
                                = indexes.CalculateStandardDeviationNbDrawsBetweenOccurrences(variance)
                        };
                    }
                )
                .ToList(),
            Balls = Enumerable.Range(Ball.MinValue, Ball.ValueCount)
                .Select(b =>
                    {
                        OccurrenceIndexes indexes = ballOccurrenceIndexes[b];
                        int[] gaps = indexes.CalculateNbDrawsBetweenOccurrences();
                        double average = indexes.CalculateAverageNbDrawsBetweenOccurrences(gaps);
                        double variance = indexes.CalculateVarianceNbDrawsBetweenOccurrences(gaps, average);

                        return new BallStatisticsModel
                        {
                            Ball = b,
                            NbTimesDraw = indexes.Count,
                            NbDrawsSinceLastOccurrence = indexes.CalculateNbDrawsSinceLastOccurrence(draws.Count),
                            AverageNbDrawsBetweenOccurrences = average,
                            MinimumNbDrawsBetweenOccurrences
                                = indexes.CalculateMinimumNbDrawsBetweenOccurrences(gaps),
                            MaximumNbDrawsBetweenOccurrences
                                = indexes.CalculateMaximumNbDrawsBetweenOccurrences(gaps),
                            VarianceNbDrawsBetweenOccurrences = variance,
                            StandardDeviationNbDrawsBetweenOccurrences
                                = indexes.CalculateStandardDeviationNbDrawsBetweenOccurrences(variance)
                        };
                    }
                )
                .ToList()
        };
    }
}

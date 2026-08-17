using EuroMillions.Application.Models;

namespace EuroMillions.Application.Extensions;

internal static class OccurrenceIndexesExtensions
{
    extension(OccurrenceIndexes indexes)
    {
        public int[] CalculateNbDrawsBetweenOccurrences()
            => indexes
                .Zip(indexes.Skip(1), (previous, current) => current - previous - 1)
                .ToArray();

        public int CalculateNbDrawsSinceLastOccurrence(int drawCount)
            => indexes.Count == 0 ? drawCount : drawCount - indexes[^1] - 1;

        public double CalculateAverageNbDrawsBetweenOccurrences(int[] gaps)
        {
            if (indexes.Count == 0)
            {
                return 0;
            }

            if (indexes.Count == 1)
            {
                return indexes[0];
            }

            return gaps.Average();
        }

        public int CalculateMinimumNbDrawsBetweenOccurrences(int[] gaps)
            => gaps.Length == 0 ? 0 : gaps.Min();

        public int CalculateMaximumNbDrawsBetweenOccurrences(int[] gaps)
            => gaps.Length == 0 ? 0 : gaps.Max();

        public double CalculateVarianceNbDrawsBetweenOccurrences(int[] gaps, double average)
            => gaps.Length == 0 ? 0 : gaps.Average(gap => Math.Pow(gap - average, 2));

        public double CalculateStandardDeviationNbDrawsBetweenOccurrences(double variance)
            => Math.Sqrt(variance);
    }
}

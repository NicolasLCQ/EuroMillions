using EuroMillions.Application.Models;

namespace EuroMillions.Application.Extensions;

internal static class OccurrenceGapsExtensions
{
    extension(OccurrenceGaps gaps)
    {
        public int CalculateMinimumNbDrawsBetweenOccurrences()
            => gaps.Count == 0 ? 0 : gaps.Min();

        public int CalculateMaximumNbDrawsBetweenOccurrences()
            => gaps.Count == 0 ? 0 : gaps.Max();

        public (double Average, double Variance, double StandardDeviation)
            CalculateAverageVarianceAndStandardDeviationNbDrawsBetweenOccurrences()
        {
            int count = 0;
            double average = 0;
            double sumSquaredDifferences = 0;

            foreach (int gap in gaps)
            {
                count++;

                double difference = gap - average;
                average += difference / count;

                double differenceAfterAverageUpdate = gap - average;
                sumSquaredDifferences += difference * differenceAfterAverageUpdate;
            }

            if (count == 0)
            {
                return (0, 0, 0);
            }

            double variance = sumSquaredDifferences / count;

            return (average, variance, Math.Sqrt(variance));
        }
    }
}

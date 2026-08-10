using EuroMillions.Application.Models;

namespace EuroMillions.Application.Extensions;

internal static class OccurrenceIndexesExtensions
{
    extension(OccurrenceIndexes indexes)
    {
        public double CalculateAverageNbDrawsBetweenOccurrences()
        {
            if (indexes.Count == 0)
            {
                return 0;
            }

            if (indexes.Count == 1)
            {
                return indexes[0];
            }

            return indexes
                .Zip(indexes.Skip(1), (previous, current) => current - previous - 1)
                .Average();
        }
    }
}

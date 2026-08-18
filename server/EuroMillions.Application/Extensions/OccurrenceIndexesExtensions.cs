using EuroMillions.Application.Models;

namespace EuroMillions.Application.Extensions;

internal static class OccurrenceIndexesExtensions
{
    extension(OccurrenceIndexes indexes)
    {
        public OccurrenceGaps CalculateNbDrawsBetweenOccurrences()
            => new OccurrenceGaps(
                indexes.Zip(indexes.Skip(1), (previous, current) => current - previous - 1)
            );

        public int CalculateNbDrawsSinceLastOccurrence(int drawCount)
            => indexes.Count == 0 ? drawCount : drawCount - indexes[^1] - 1;
    }
}

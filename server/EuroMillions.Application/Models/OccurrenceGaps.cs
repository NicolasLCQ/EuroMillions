namespace EuroMillions.Application.Models;

internal sealed class OccurrenceGaps(IEnumerable<int> gaps) : List<int>(gaps);

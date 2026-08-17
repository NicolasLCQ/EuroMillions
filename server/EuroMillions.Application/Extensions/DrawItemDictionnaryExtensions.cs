using EuroMillions.Application.Models;

namespace EuroMillions.Application.Extensions;

public static class DrawItemDictionnaryExtensions
{
    internal static void AddOccurrenceIndexes<TItem>(
        this DrawItemDictionnary<TItem, OccurrenceIndexes> dictionnary,
        IEnumerable<TItem> items,
        int index
    )
        where TItem : notnull
    {
        foreach (TItem item in items)
        {
            dictionnary.Items[item].Add(index);
        }
    }
}

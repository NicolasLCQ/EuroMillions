using EuroMillions.Application.Models;

namespace EuroMillions.Application.Extensions;

public static class DrawItemDictionnaryExtensions
{
    public static void Increment<TItem>(
        this DrawItemDictionnary<TItem> dictionnary,
        IEnumerable<TItem> items)
        where TItem : notnull
    {
        foreach (TItem item in items)
        {
            dictionnary.Items[item]++;
        }
    }
}

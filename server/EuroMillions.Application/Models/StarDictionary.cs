namespace EuroMillions.Application.Models;

public sealed class StarDictionary<TValue>(Func<Star, TValue> valueFactory)
    : DrawItemDictionnary<Star, TValue>(
        Enumerable.Range(Star.MinValue, Star.ValueCount).Select(star => (Star)star),
        valueFactory
    );

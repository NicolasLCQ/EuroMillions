namespace EuroMillions.Application.Models;

public sealed class StarDictionary()
    : DrawItemDictionnary<Star>(
        Enumerable.Range(Star.MinValue, Star.ValueCount).Select(star => (Star)star)
    );

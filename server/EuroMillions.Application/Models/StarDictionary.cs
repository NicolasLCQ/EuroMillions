namespace EuroMillions.Application.Models;

public sealed class StarDictionary() : DrawItemDictionnary<Star>(Enumerable.Range(1, 12).Select(star => (Star)star));

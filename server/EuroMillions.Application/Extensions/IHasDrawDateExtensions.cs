using EuroMillions.Application.Models;

namespace EuroMillions.Application.Extensions;

public static class IHasDrawDateExtensions
{
    public static DateTime GetPublicationDate(this IHasDrawDate source) => source.DrawDate.AddDays(1);
}

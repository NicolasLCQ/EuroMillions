using EuroMillions.Application.Models;

namespace EuroMillions.Application.Extensions;

public static class StarExtensions
{
    public static void Validate(this Star star)
    {
        if ((star < 0) || (star > 50))
        {
            throw new ArgumentOutOfRangeException(nameof(star), "Le nombre doit être compris entre 0 et 50.");
        }
    }
}

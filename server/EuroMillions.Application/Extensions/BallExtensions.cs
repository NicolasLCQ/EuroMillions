using EuroMillions.Application.Models;

namespace EuroMillions.Application.Extensions;

public static class BallExtensions
{
    public static void Validate(this Ball ball)
    {
        if ((ball < 0) || (ball > 50))
        {
            throw new ArgumentOutOfRangeException(nameof(ball), "Le nombre doit être compris entre 0 et 50.");
        }
    }
}

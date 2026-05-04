using EuroMillions.Application.Models;

namespace EuroMillions.Application.Extensions;

public static class DrawExtensions
{
    public static void Validate(this Draw draw)
    {
        HashSet<int> balls = new HashSet<int>
        {
            draw.Ball1,
            draw.Ball2,
            draw.Ball3,
            draw.Ball4,
            draw.Ball5
        };

        if (balls.Count != 5)
        {
            throw new ArgumentException("Les numéros doivent être uniques.");
        }

        if (draw.Star1 == draw.Star2)
        {
            throw new ArgumentException("Les étoiles doivent être uniques.");
        }
    }
}

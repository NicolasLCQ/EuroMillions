using EuroMillions.Application.Models;

namespace EuroMillions.Application.Extensions;

public static class MinimalDrawModelExtensions
{
    public static (BallDictionary Balls, StarDictionary Stars) CalculateNbTimesDraw(
        this IEnumerable<MinimalDrawModel> draws)
    {
        BallDictionary ballDictionary = new BallDictionary();
        StarDictionary starDictionary = new StarDictionary();

        foreach (MinimalDrawModel draw in draws)
        {
            ballDictionary.Increment([draw.Ball1, draw.Ball2, draw.Ball3, draw.Ball4, draw.Ball5]);
            starDictionary.Increment([draw.Star1, draw.Star2]);
        }

        return (ballDictionary, starDictionary);
    }
}

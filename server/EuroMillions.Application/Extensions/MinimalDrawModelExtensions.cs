using EuroMillions.Application.Models;

namespace EuroMillions.Application.Extensions;

public static class MinimalDrawModelExtensions
{
    public static (BallDictionary Balls, StarDictionary Stars) CalculateNbTimesDraw(this IEnumerable<MinimalDrawModel> draws)
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

    public static (BallDictionary Balls, StarDictionary Stars) CalculateNbDrawsSinceLastOccurrence(
        this IEnumerable<MinimalDrawModel> draws
    )
    {
        BallDictionary ballDictionary = new BallDictionary();
        StarDictionary starDictionary = new StarDictionary();
        HashSet<Ball> ballsWithoutOccurrence = ballDictionary.Keys.ToHashSet();
        HashSet<Star> starsWithoutOccurrence = starDictionary.Keys.ToHashSet();

        foreach (MinimalDrawModel draw in draws)
        {
            Ball[] drawnBalls = [draw.Ball1, draw.Ball2, draw.Ball3, draw.Ball4, draw.Ball5];
            Star[] drawnStars = [draw.Star1, draw.Star2];

            ballDictionary.Increment(ballsWithoutOccurrence.Except(drawnBalls));
            starDictionary.Increment(starsWithoutOccurrence.Except(drawnStars));

            ballsWithoutOccurrence.ExceptWith(drawnBalls);
            starsWithoutOccurrence.ExceptWith(drawnStars);
        }

        return (ballDictionary, starDictionary);
    }
}

using EuroMillions.Application.Models;

namespace EuroMillions.Application.Extensions;

public static class MinimalDrawModelExtensions
{
    extension(IEnumerable<MinimalDrawModel> draws)
    {
        public (BallDictionary Balls, StarDictionary Stars) CalculateNbTimesDraw()
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

        public (BallDictionary Balls, StarDictionary Stars) CalculateNbDrawsSinceLastOccurrence()
        {
            BallDictionary ballDictionary = new BallDictionary();
            StarDictionary starDictionary = new StarDictionary();
            HashSet<Ball> ballsWithoutOccurrence = ballDictionary.Keys.ToHashSet();
            HashSet<Star> starsWithoutOccurrence = starDictionary.Keys.ToHashSet();

            foreach (MinimalDrawModel draw in draws)
            {
                Ball[] drawnBalls = [draw.Ball1, draw.Ball2, draw.Ball3, draw.Ball4, draw.Ball5];
                Star[] drawnStars = [draw.Star1, draw.Star2];

                ballsWithoutOccurrence.ExceptWith(drawnBalls);
                starsWithoutOccurrence.ExceptWith(drawnStars);

                if ((ballsWithoutOccurrence.Count == 0) && (starsWithoutOccurrence.Count == 0))
                {
                    break;
                }

                ballDictionary.Increment(ballsWithoutOccurrence);
                starDictionary.Increment(starsWithoutOccurrence);
            }

            return (ballDictionary, starDictionary);
        }
    }
}

using EuroMillions.Application.Models;

namespace EuroMillions.Application.Extensions;

public static class MinimalDrawModelExtensions
{
    extension(IEnumerable<MinimalDrawModel> draws)
    {
        public (BallDictionary<int> Balls, StarDictionary<int> Stars) CalculateNbTimesDraw()
        {
            BallDictionary<int> ballDictionary = new BallDictionary<int>(_ => 0);
            StarDictionary<int> starDictionary = new StarDictionary<int>(_ => 0);

            foreach (MinimalDrawModel draw in draws)
            {
                ballDictionary.Increment([draw.Ball1, draw.Ball2, draw.Ball3, draw.Ball4, draw.Ball5]);
                starDictionary.Increment([draw.Star1, draw.Star2]);
            }

            return (ballDictionary, starDictionary);
        }

        public (BallDictionary<int> Balls, StarDictionary<int> Stars) CalculateNbDrawsSinceLastOccurrence()
        {
            BallDictionary<int> ballDictionary = new BallDictionary<int>(_ => 0);
            StarDictionary<int> starDictionary = new StarDictionary<int>(_ => 0);
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

        public (BallDictionary<double> Balls, StarDictionary<double> Stars)
            CalculateAverageNbDrawsBetweenOccurrences()
        {
            BallDictionary<OccurrenceIndexes> ballOccurrenceIndexes = new BallDictionary<OccurrenceIndexes>(_ => []);
            StarDictionary<OccurrenceIndexes> starOccurrenceIndexes = new StarDictionary<OccurrenceIndexes>(_ => []);

            int drawIndex = 0;

            foreach (MinimalDrawModel draw in draws.Reverse())
            {
                ballOccurrenceIndexes.AddOccurrenceIndexes(
                    [draw.Ball1, draw.Ball2, draw.Ball3, draw.Ball4, draw.Ball5],
                    drawIndex
                );

                starOccurrenceIndexes.AddOccurrenceIndexes([draw.Star1, draw.Star2], drawIndex);
                drawIndex++;
            }

            BallDictionary<double> ballAverages
                = new BallDictionary<double>(ball => ballOccurrenceIndexes[ball].CalculateAverageNbDrawsBetweenOccurrences()
                );

            StarDictionary<double> starAverages
                = new StarDictionary<double>(star => starOccurrenceIndexes[star].CalculateAverageNbDrawsBetweenOccurrences()
                );

            return (ballAverages, starAverages);
        }

        public (BallDictionary<int> Balls, StarDictionary<int> Stars)
            CalculateMinimumNbDrawsBetweenOccurrences()
        {
            BallDictionary<OccurrenceIndexes> ballOccurrenceIndexes = new BallDictionary<OccurrenceIndexes>(_ => []);
            StarDictionary<OccurrenceIndexes> starOccurrenceIndexes = new StarDictionary<OccurrenceIndexes>(_ => []);

            int drawIndex = 0;

            foreach (MinimalDrawModel draw in draws.Reverse())
            {
                ballOccurrenceIndexes.AddOccurrenceIndexes(
                    [draw.Ball1, draw.Ball2, draw.Ball3, draw.Ball4, draw.Ball5],
                    drawIndex
                );

                starOccurrenceIndexes.AddOccurrenceIndexes([draw.Star1, draw.Star2], drawIndex);
                drawIndex++;
            }

            BallDictionary<int> ballMinimums
                = new BallDictionary<int>(ball =>
                    ballOccurrenceIndexes[ball].CalculateMinimumNbDrawsBetweenOccurrences()
                );

            StarDictionary<int> starMinimums
                = new StarDictionary<int>(star =>
                    starOccurrenceIndexes[star].CalculateMinimumNbDrawsBetweenOccurrences()
                );

            return (ballMinimums, starMinimums);
        }

        public (BallDictionary<int> Balls, StarDictionary<int> Stars)
            CalculateMaximumNbDrawsBetweenOccurrences()
        {
            BallDictionary<OccurrenceIndexes> ballOccurrenceIndexes = new BallDictionary<OccurrenceIndexes>(_ => []);
            StarDictionary<OccurrenceIndexes> starOccurrenceIndexes = new StarDictionary<OccurrenceIndexes>(_ => []);

            int drawIndex = 0;

            foreach (MinimalDrawModel draw in draws.Reverse())
            {
                ballOccurrenceIndexes.AddOccurrenceIndexes(
                    [draw.Ball1, draw.Ball2, draw.Ball3, draw.Ball4, draw.Ball5],
                    drawIndex
                );

                starOccurrenceIndexes.AddOccurrenceIndexes([draw.Star1, draw.Star2], drawIndex);
                drawIndex++;
            }

            BallDictionary<int> ballMaximums
                = new BallDictionary<int>(ball =>
                    ballOccurrenceIndexes[ball].CalculateMaximumNbDrawsBetweenOccurrences()
                );

            StarDictionary<int> starMaximums
                = new StarDictionary<int>(star =>
                    starOccurrenceIndexes[star].CalculateMaximumNbDrawsBetweenOccurrences()
                );

            return (ballMaximums, starMaximums);
        }

        public (BallDictionary<double> Balls, StarDictionary<double> Stars)
            CalculateVarianceNbDrawsBetweenOccurrences()
        {
            BallDictionary<OccurrenceIndexes> ballOccurrenceIndexes = new BallDictionary<OccurrenceIndexes>(_ => []);
            StarDictionary<OccurrenceIndexes> starOccurrenceIndexes = new StarDictionary<OccurrenceIndexes>(_ => []);

            int drawIndex = 0;

            foreach (MinimalDrawModel draw in draws.Reverse())
            {
                ballOccurrenceIndexes.AddOccurrenceIndexes(
                    [draw.Ball1, draw.Ball2, draw.Ball3, draw.Ball4, draw.Ball5],
                    drawIndex
                );

                starOccurrenceIndexes.AddOccurrenceIndexes([draw.Star1, draw.Star2], drawIndex);
                drawIndex++;
            }

            BallDictionary<double> ballVariances
                = new BallDictionary<double>(ball =>
                    ballOccurrenceIndexes[ball].CalculateVarianceNbDrawsBetweenOccurrences()
                );

            StarDictionary<double> starVariances
                = new StarDictionary<double>(star =>
                    starOccurrenceIndexes[star].CalculateVarianceNbDrawsBetweenOccurrences()
                );

            return (ballVariances, starVariances);
        }

        public (BallDictionary<double> Balls, StarDictionary<double> Stars)
            CalculateStandardDeviationNbDrawsBetweenOccurrences()
        {
            BallDictionary<OccurrenceIndexes> ballOccurrenceIndexes = new BallDictionary<OccurrenceIndexes>(_ => []);
            StarDictionary<OccurrenceIndexes> starOccurrenceIndexes = new StarDictionary<OccurrenceIndexes>(_ => []);

            int drawIndex = 0;

            foreach (MinimalDrawModel draw in draws.Reverse())
            {
                ballOccurrenceIndexes.AddOccurrenceIndexes(
                    [draw.Ball1, draw.Ball2, draw.Ball3, draw.Ball4, draw.Ball5],
                    drawIndex
                );

                starOccurrenceIndexes.AddOccurrenceIndexes([draw.Star1, draw.Star2], drawIndex);
                drawIndex++;
            }

            BallDictionary<double> ballStandardDeviations
                = new BallDictionary<double>(ball =>
                    ballOccurrenceIndexes[ball].CalculateStandardDeviationNbDrawsBetweenOccurrences()
                );

            StarDictionary<double> starStandardDeviations
                = new StarDictionary<double>(star =>
                    starOccurrenceIndexes[star].CalculateStandardDeviationNbDrawsBetweenOccurrences()
                );

            return (ballStandardDeviations, starStandardDeviations);
        }
    }
}

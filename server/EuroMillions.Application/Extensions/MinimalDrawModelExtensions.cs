using EuroMillions.Application.Models;

namespace EuroMillions.Application.Extensions;

public static class MinimalDrawModelExtensions
{
    extension(IEnumerable<MinimalDrawModel> draws)
    {
        internal (BallDictionary<OccurrenceIndexes> Balls, StarDictionary<OccurrenceIndexes> Stars)
            CalculateOccurrenceIndexes()
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

            return (ballOccurrenceIndexes, starOccurrenceIndexes);
        }
    }
}

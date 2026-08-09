namespace EuroMillions.Application.Models;

public sealed class BallDictionary()
    : DrawItemDictionnary<Ball>(
        Enumerable.Range(Ball.MinValue, Ball.ValueCount).Select(ball => (Ball)ball)
    );

namespace EuroMillions.Application.Models;

public sealed class BallDictionary<TValue>(Func<Ball, TValue> valueFactory)
    : DrawItemDictionnary<Ball, TValue>(
        Enumerable.Range(Ball.MinValue, Ball.ValueCount).Select(ball => (Ball)ball),
        valueFactory
    );

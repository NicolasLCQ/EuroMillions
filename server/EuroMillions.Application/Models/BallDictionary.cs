namespace EuroMillions.Application.Models;

public sealed class BallDictionary() : DrawItemDictionnary<Ball>(Enumerable.Range(1, 50).Select(ball => (Ball)ball));

namespace EuroMillions.Application.Models;

public record Ball : DrawItemAbstraction
{
    public const int MinValue = 1;
    public const int MaxValue = 50;
    public const int ValueCount = (MaxValue - MinValue) + 1;

    private Ball(int ball)
        : base(ball) {}

    public static implicit operator Ball(int ball)
    {
        if ((ball < MinValue) || (ball > MaxValue))
        {
            throw new ArgumentException($"The ball must be between {MinValue} and {MaxValue}.");
        }

        return new Ball(ball);
    }
}

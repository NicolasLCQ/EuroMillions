namespace EuroMillions.Application.Models;

public class Ball
{
    private readonly int _value;

    private Ball(int ball) => _value = ball;

    public override string ToString() => _value.ToString();

    public static implicit operator int(Ball ball) => ball._value;

    public static implicit operator Ball(int ball)
    {
        if ((ball < 0) || (ball > 50))
        {
            throw new ArgumentException("The ball must be between 0 and 50.");
        }
        return new Ball(ball);
    }
}

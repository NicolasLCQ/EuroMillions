namespace EuroMillions.Application.Models;

public class Ball
{
    private readonly int _value;

    private Ball(int ball) => _value = ball;

    public override string ToString() => _value.ToString();

    public static implicit operator int(Ball ball) => ball._value;

    public static implicit operator Ball(int ball) => new Ball(ball);
}

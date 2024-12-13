namespace EuroMillions.Data.Models;

public class Ball
{
    private readonly int _value;

    private Ball(int ball)
    {
        if (ball < 0 || ball > 50)
        {
            throw new ArgumentOutOfRangeException(nameof(ball), "Le nombre doit être compris entre 0 et 50.");
        }

        _value = ball;
    }

    public override string ToString() => _value.ToString();

    public static implicit operator int(Ball ball) => ball._value;

    public static implicit operator Ball(int ball) => new(ball);
}

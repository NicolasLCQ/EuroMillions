namespace EuroMillions.Application.Models;

public record Ball : DrawItemAbstraction
{
    private Ball(int ball)
        : base(ball) {}

    public static implicit operator Ball(int ball)
    {
        if ((ball < 0) || (ball > 50))
        {
            throw new ArgumentException("The ball must be between 0 and 50.");
        }

        return new Ball(ball);
    }
}

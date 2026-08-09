namespace EuroMillions.Application.Models;

public record Star : DrawItemAbstraction
{
    public const int MinValue = 1;
    public const int MaxValue = 12;
    public const int ValueCount = (MaxValue - MinValue) + 1;

    private Star(int star)
        : base(star) {}

    public static implicit operator Star(int star)
    {
        if ((star < MinValue) || (star > MaxValue))
        {
            throw new ArgumentException($"Le nombre doit être compris entre {MinValue} et {MaxValue}.");
        }

        return new Star(star);
    }
}

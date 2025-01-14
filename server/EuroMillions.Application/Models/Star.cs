namespace EuroMillions.Application.Models;

public class Star
{
    private readonly int _value;

    private Star(int start)
    {
        if ((start < 0) || (start > 50))
        {
            throw new ArgumentOutOfRangeException(nameof(start), "Le nombre doit être compris entre 0 et 50.");
        }

        _value = start;
    }

    public override string ToString() => _value.ToString();

    public static implicit operator int(Star star) => star._value;

    public static implicit operator Star(int value) => new Star(value);
}

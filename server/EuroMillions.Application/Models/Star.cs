namespace EuroMillions.Application.Models;

public class Star
{
    private readonly int _value;

    private Star(int start) => _value = start;

    public override string ToString() => _value.ToString();

    public static implicit operator int(Star star) => star._value;

    public static implicit operator Star(int star)
    {
        if ((star < 0) || (star > 12))
        {
            throw new ArgumentException( "Le nombre doit être compris entre 0 et 12.");
        }

        return new Star(star);
    }
}

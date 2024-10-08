namespace EuroMillions.Data.Models;

public class Number
{
    private readonly int _value;

    private Number(int number)
    {
        if (number < 0 || number > 50)
        {
            throw new ArgumentOutOfRangeException(nameof(number), "Le nombre doit être compris entre 0 et 50.");
        }

        _value = number;
    }

    public override string ToString() => _value.ToString();

    public static implicit operator int(Number number) => number._value;

    public static implicit operator Number(int number) => new(number);
}

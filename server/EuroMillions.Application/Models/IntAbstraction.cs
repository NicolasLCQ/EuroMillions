namespace EuroMillions.Application.Models;

public abstract record IntAbstraction
{
    private readonly int _value;
    protected IntAbstraction(int value) => _value = value;
    public sealed override string ToString() => _value.ToString();
    public static implicit operator int(IntAbstraction intAbstraction) => intAbstraction._value;
}

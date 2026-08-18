namespace EuroMillions.Application.Models;

public abstract record DrawItemAbstraction : IntAbstraction
{
    protected DrawItemAbstraction(int value)
        : base(value) {}
}

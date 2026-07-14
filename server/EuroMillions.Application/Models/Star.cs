namespace EuroMillions.Application.Models;

public record Star : DrawItemAbstraction
{
    private Star(int star)
        : base(star) {}

    public static implicit operator Star(int star)
    {
        if ((star < 0) || (star > 12))
        {
            throw new ArgumentException("Le nombre doit être compris entre 0 et 12.");
        }

        return new Star(star);
    }
}

namespace EuroMillions.Data.Models;

public class Draw
{
    public Number Number1 { get; private set; }
    public Number Number2 { get; private set; }
    public Number Number3 { get; private set; }
    public Number Number4 { get; private set; }
    public Number Number5 { get; private set; }
    public Star Star1 { get; private set; }
    public Star Star2 { get; private set; }

    public Draw(Number number1, Number number2, Number number3, Number number4, Number number5, Star star1, Star star2)
    {

        // Validation des nombres pour éviter les doublons
        var numbers = new HashSet<int> { number1, number2, number3, number4, number5 };
        if (numbers.Count != 5)
        {
            throw new ArgumentException("Les numéros doivent être uniques.");
        }

        if (star1 == star2)
        {
            throw new ArgumentException("Les étoiles doivent être uniques.");
        }

        Number1 = number1;
        Number2 = number2;
        Number3 = number3;
        Number4 = number4;
        Number5 = number5;
        Star1 = star1;
        Star2 = star2;
    }
}
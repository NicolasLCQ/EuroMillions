namespace EuroMillions.Data.Models;

public class Draw
{
    public int? Id { get; set; }
    public int YearDrawNumber { get; set; }
    public DateTime DrawDate { get; set; }

    public Ball Ball1 { get; private set; }
    public Ball Ball2 { get; private set; }
    public Ball Ball3 { get; private set; }
    public Ball Ball4 { get; private set; }
    public Ball Ball5 { get; private set; }
    public Star Star1 { get; private set; }
    public Star Star2 { get; private set; }

    public Draw(Ball ball1, Ball ball2, Ball ball3, Ball ball4, Ball ball5, Star star1, Star star2)
    {
        HashSet<int>? balls = new()
        {
            ball1,
            ball2,
            ball3,
            ball4,
            ball5
        };

        if (balls.Count != 5)
        {
            throw new ArgumentException("Les numéros doivent être uniques.");
        }

        if (star1 == star2)
        {
            throw new ArgumentException("Les étoiles doivent être uniques.");
        }

        Ball1 = ball1;
        Ball2 = ball2;
        Ball3 = ball3;
        Ball4 = ball4;
        Ball5 = ball5;
        Star1 = star1;
        Star2 = star2;
    }

    public Draw(int yearDrawNumber, DateTime drawDate, Ball ball1, Ball ball2, Ball ball3, Ball ball4, Ball ball5, Star star1, Star star2)
    {
        HashSet<int>? balls = new()
        {
            ball1,
            ball2,
            ball3,
            ball4,
            ball5
        };

        if (balls.Count != 5)
        {
            throw new ArgumentException("Les numéros doivent être uniques.");
        }

        if (star1 == star2)
        {
            throw new ArgumentException("Les étoiles doivent être uniques.");
        }

        Ball1 = ball1;
        Ball2 = ball2;
        Ball3 = ball3;
        Ball4 = ball4;
        Ball5 = ball5;
        Star1 = star1;
        Star2 = star2;

        YearDrawNumber = yearDrawNumber;
        DrawDate = drawDate;
    }
}

namespace EuroMillions.Application.Models;

using Data.Models;

public class Draw
{
    public int? Id { get; set; }
    public int YearDrawNumber { get; set; }
    public DateTime DrawDate { get; set; }

    private Ball _ball1; public int Ball1 { get => (int)_ball1; }
    private Ball _ball2; public int Ball2 { get => (int)_ball2; }
    private Ball _ball3; public int Ball3 { get => (int)_ball3; }
    private Ball _ball4; public int Ball4 { get => (int)_ball4; }
    private Ball _ball5; public int Ball5 { get => (int)_ball5; }
    private Star _star1; public int Star1 { get => (int)_star1; }
    private Star _star2; public int Star2 { get => (int)_star2; }

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

        _ball1 = ball1;
        _ball2 = ball2;
        _ball3 = ball3;
        _ball4 = ball4;
        _ball5 = ball5;
        _star1 = star1;
        _star2 = star2;

        YearDrawNumber = yearDrawNumber;
        DrawDate = drawDate;
    }

    public Draw(int dbId, int yearDrawNumber, DateTime drawDate, Ball ball1, Ball ball2, Ball ball3, Ball ball4, Ball ball5, Star star1, Star star2)
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
            throw new ArgumentException("Numbers must be unique");
        }

        if (star1 == star2)
        {
            throw new ArgumentException("Stars must be unique");
        }

        _ball1 = ball1;
        _ball2 = ball2;
        _ball3 = ball3;
        _ball4 = ball4;
        _ball5 = ball5;
        _star1 = star1;
        _star2 = star2;

        YearDrawNumber = yearDrawNumber;
        DrawDate = drawDate;
        Id = dbId;
    }
}

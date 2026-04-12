using EuroMillions.Application.Models;
using EuroMillions.Application.Models.Upload;

namespace EuroMillions.Application.Extensions;

public static class DrawExtensions
{
    public static void Validate(this Draw draw)
    {
        draw.Ball1.Validate();
        draw.Ball2.Validate();
        draw.Ball3.Validate();
        draw.Ball4.Validate();
        draw.Ball5.Validate();

        draw.Star1.Validate();
        draw.Star2.Validate();

        HashSet<int> balls = new HashSet<int>
        {
            draw.Ball1,
            draw.Ball2,
            draw.Ball3,
            draw.Ball4,
            draw.Ball5
        };

        if (balls.Count != 5)
        {
            throw new ArgumentException("Les num�ros doivent �tre uniques.");
        }

        if (draw.Star1 == draw.Star2)
        {
            throw new ArgumentException("Les �toiles doivent �tre uniques.");
        }
    }

    public static RejectedDraw ToRejectedDraw(this Draw draw, string reason) =>
        new RejectedDraw
        {
            YearDrawNumber = draw.YearDrawNumber,
            DrawDate = draw.DrawDate,
            Ball1 = draw.Ball1,
            Ball2 = draw.Ball2,
            Ball3 = draw.Ball3,
            Ball4 = draw.Ball4,
            Ball5 = draw.Ball5,
            Star1 = draw.Star1,
            Star2 = draw.Star2,
            Reason = reason
        };
}

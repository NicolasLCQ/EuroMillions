using EuroMillions.Application.Models;
using EuroMillions.Infrastructure.Entities;

namespace EuroMillions.Infrastructure.Mappers.EntityMappers;

public static class T_DrawMapper
{
    public static T_DRAW ToEntity(this Draw draw) =>
        new T_DRAW
        {
            YEAR_DRAW_NUMBER = draw.YearDrawNumber,
            DRAW_DATE = draw.DrawDate,
            BALL_ONE = draw.Ball1,
            BALL_TWO = draw.Ball2,
            BALL_THREE = draw.Ball3,
            BALL_FOUR = draw.Ball4,
            BALL_FIVE = draw.Ball5,
            STAR_ONE = draw.Star1,
            STAR_TWO = draw.Star2
        };

    public static Draw ToModel(this T_DRAW tDraw) => new Draw
    {
        YearDrawNumber = tDraw.YEAR_DRAW_NUMBER,
        DrawDate = tDraw.DRAW_DATE,
        Ball1 = tDraw.BALL_ONE,
        Ball2 = tDraw.BALL_TWO,
        Ball3 = tDraw.BALL_THREE,
        Ball4 = tDraw.BALL_FOUR,
        Ball5 = tDraw.BALL_FIVE,
        Star1 = tDraw.STAR_ONE,
        Star2 = tDraw.STAR_TWO
    };
}

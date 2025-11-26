using EuroMillions.Application.Models;
using EuroMillions.Infrastructure.Entities;

namespace EuroMillions.Infrastructure.Mappers.EntityMappers;

public static class T_DrawMapper
{
    public static T_DRAW FromModel(Draw draw) =>
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

    public static Draw ToModel(this T_DRAW tDraw) => new Draw(
        tDraw.ID,
        tDraw.YEAR_DRAW_NUMBER,
        tDraw.DRAW_DATE,
        tDraw.BALL_ONE,
        tDraw.BALL_TWO,
        tDraw.BALL_THREE,
        tDraw.BALL_FOUR,
        tDraw.BALL_FIVE,
        tDraw.STAR_ONE,
        tDraw.STAR_TWO
    );
}

namespace EuroMillions.Infrastructure.Mappers.EntityMappers;

using Application.Models;

using Entities;

public static class T_DrawMapper
{
    public static T_DRAW FromModel(this T_DRAW tDraw, Draw draw)
    {
        tDraw.YEAR_DRAW_NUMBER = draw.YearDrawNumber;
        tDraw.DRAW_DATE = draw.DrawDate;
        tDraw.BALL_ONE = draw.Ball1;
        tDraw.BALL_TWO = draw.Ball2;
        tDraw.BALL_THREE = draw.Ball3;
        tDraw.BALL_FOUR = draw.Ball4;
        tDraw.BALL_FIVE = draw.Ball5;
        tDraw.STAR_ONE = draw.Star1;
        tDraw.STAR_TWO = draw.Star2;

        return tDraw;
    }

    public static Draw ToModel(this T_DRAW tDraw) => new(tDraw.ID, tDraw.YEAR_DRAW_NUMBER, tDraw.DRAW_DATE, tDraw.BALL_ONE, tDraw.BALL_TWO, tDraw.BALL_THREE, tDraw.BALL_FOUR, tDraw.BALL_FIVE, tDraw.STAR_ONE, tDraw.STAR_TWO);
}

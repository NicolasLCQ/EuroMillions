using EuroMillions.Application.Models;
using EuroMillions.Infrastructure.Entities;
using EuroMillions.Infrastructure.Helpers;

namespace EuroMillions.Infrastructure.Mappers.EntityMappers;

public static class T_DrawMapper
{
    private static double? ToDouble(decimal? value) => value.HasValue ? (double)value.Value : null;

    public static T_DRAW ToDrawEntity(this Draw draw) =>
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
            STAR_TWO = draw.Star2,
            DRAW_DAY = draw.DrawDay,
            FORCLUSION_DATE = draw.ForclusionDate,
            DRAW_NUMBER_IN_CYCLE = draw.DrawNumberInCycle?.ToString(),
            WINNING_BALLS_IN_ASCENDING_ORDER = draw.WinningBallsInAscendingOrder,
            WINNING_STARS_IN_ASCENDING_ORDER = draw.WinningStarsInAscendingOrder,
            JOKER_PLUS_NUMBER = draw.JokerPlusNumber,
            MY_MILLION_NUMBER = draw.MyMillionNumber,
            EXCEPTIONAL_EURO_MILLIONS_DRAW_NUMBER = draw.ExceptionalEuroMillionsDrawNumber,
            CURRENCY = draw.Currency,
            RANK_1_EURO_MILLIONS_WINNERS_FRANCE = draw.Rank1EuroMillionsWinnersFrance,
            RANK_1_EURO_MILLIONS_WINNERS_EUROPE = draw.Rank1EuroMillionsWinnersEurope,
            RANK_1_EURO_MILLIONS_PRIZE = ToDouble(draw.Rank1EuroMillionsPrize),
            RANK_2_EURO_MILLIONS_WINNERS_FRANCE = draw.Rank2EuroMillionsWinnersFrance,
            RANK_2_EURO_MILLIONS_WINNERS_EUROPE = draw.Rank2EuroMillionsWinnersEurope,
            RANK_2_EURO_MILLIONS_PRIZE = ToDouble(draw.Rank2EuroMillionsPrize),
            RANK_3_EURO_MILLIONS_WINNERS_FRANCE = draw.Rank3EuroMillionsWinnersFrance,
            RANK_3_EURO_MILLIONS_WINNERS_EUROPE = draw.Rank3EuroMillionsWinnersEurope,
            RANK_3_EURO_MILLIONS_PRIZE = ToDouble(draw.Rank3EuroMillionsPrize),
            RANK_4_EURO_MILLIONS_WINNERS_FRANCE = draw.Rank4EuroMillionsWinnersFrance,
            RANK_4_EURO_MILLIONS_WINNERS_EUROPE = draw.Rank4EuroMillionsWinnersEurope,
            RANK_4_EURO_MILLIONS_PRIZE = ToDouble(draw.Rank4EuroMillionsPrize),
            RANK_5_EURO_MILLIONS_WINNERS_FRANCE = draw.Rank5EuroMillionsWinnersFrance,
            RANK_5_EURO_MILLIONS_WINNERS_EUROPE = draw.Rank5EuroMillionsWinnersEurope,
            RANK_5_EURO_MILLIONS_PRIZE = ToDouble(draw.Rank5EuroMillionsPrize),
            RANK_6_EURO_MILLIONS_WINNERS_FRANCE = draw.Rank6EuroMillionsWinnersFrance,
            RANK_6_EURO_MILLIONS_WINNERS_EUROPE = draw.Rank6EuroMillionsWinnersEurope,
            RANK_6_EURO_MILLIONS_PRIZE = ToDouble(draw.Rank6EuroMillionsPrize),
            RANK_7_EURO_MILLIONS_WINNERS_FRANCE = draw.Rank7EuroMillionsWinnersFrance,
            RANK_7_EURO_MILLIONS_WINNERS_EUROPE = draw.Rank7EuroMillionsWinnersEurope,
            RANK_7_EURO_MILLIONS_PRIZE = ToDouble(draw.Rank7EuroMillionsPrize),
            RANK_8_EURO_MILLIONS_WINNERS_FRANCE = draw.Rank8EuroMillionsWinnersFrance,
            RANK_8_EURO_MILLIONS_WINNERS_EUROPE = draw.Rank8EuroMillionsWinnersEurope,
            RANK_8_EURO_MILLIONS_PRIZE = ToDouble(draw.Rank8EuroMillionsPrize),
            RANK_9_EURO_MILLIONS_WINNERS_FRANCE = draw.Rank9EuroMillionsWinnersFrance,
            RANK_9_EURO_MILLIONS_WINNERS_EUROPE = draw.Rank9EuroMillionsWinnersEurope,
            RANK_9_EURO_MILLIONS_PRIZE = ToDouble(draw.Rank9EuroMillionsPrize),
            RANK_10_EURO_MILLIONS_WINNERS_FRANCE = draw.Rank10EuroMillionsWinnersFrance,
            RANK_10_EURO_MILLIONS_WINNERS_EUROPE = draw.Rank10EuroMillionsWinnersEurope,
            RANK_10_EURO_MILLIONS_PRIZE = ToDouble(draw.Rank10EuroMillionsPrize),
            RANK_11_EURO_MILLIONS_WINNERS_FRANCE = draw.Rank11EuroMillionsWinnersFrance,
            RANK_11_EURO_MILLIONS_WINNERS_EUROPE = draw.Rank11EuroMillionsWinnersEurope,
            RANK_11_EURO_MILLIONS_PRIZE = ToDouble(draw.Rank11EuroMillionsPrize),
            RANK_12_EURO_MILLIONS_WINNERS_FRANCE = draw.Rank12EuroMillionsWinnersFrance,
            RANK_12_EURO_MILLIONS_WINNERS_EUROPE = draw.Rank12EuroMillionsWinnersEurope,
            RANK_12_EURO_MILLIONS_PRIZE = ToDouble(draw.Rank12EuroMillionsPrize),
            RANK_13_EURO_MILLIONS_WINNERS_FRANCE = draw.Rank13EuroMillionsWinnersFrance,
            RANK_13_EURO_MILLIONS_WINNERS_EUROPE = draw.Rank13EuroMillionsWinnersEurope,
            RANK_13_EURO_MILLIONS_PRIZE = ToDouble(draw.Rank13EuroMillionsPrize),
            RANK_1_ETOILE_PLUS_WINNERS = draw.Rank1EtoilePlusWinners,
            RANK_1_ETOILE_PLUS_PRIZE = ToDouble(draw.Rank1EtoilePlusPrize),
            RANK_2_ETOILE_PLUS_WINNERS = draw.Rank2EtoilePlusWinners,
            RANK_2_ETOILE_PLUS_PRIZE = ToDouble(draw.Rank2EtoilePlusPrize),
            RANK_3_ETOILE_PLUS_WINNERS = draw.Rank3EtoilePlusWinners,
            RANK_3_ETOILE_PLUS_PRIZE = ToDouble(draw.Rank3EtoilePlusPrize),
            RANK_4_ETOILE_PLUS_WINNERS = draw.Rank4EtoilePlusWinners,
            RANK_4_ETOILE_PLUS_PRIZE = ToDouble(draw.Rank4EtoilePlusPrize),
            RANK_5_ETOILE_PLUS_WINNERS = draw.Rank5EtoilePlusWinners,
            RANK_5_ETOILE_PLUS_PRIZE = ToDouble(draw.Rank5EtoilePlusPrize),
            RANK_6_ETOILE_PLUS_WINNERS = draw.Rank6EtoilePlusWinners,
            RANK_6_ETOILE_PLUS_PRIZE = ToDouble(draw.Rank6EtoilePlusPrize),
            RANK_7_ETOILE_PLUS_WINNERS = draw.Rank7EtoilePlusWinners,
            RANK_7_ETOILE_PLUS_PRIZE = ToDouble(draw.Rank7EtoilePlusPrize),
            RANK_8_ETOILE_PLUS_WINNERS = draw.Rank8EtoilePlusWinners,
            RANK_8_ETOILE_PLUS_PRIZE = ToDouble(draw.Rank8EtoilePlusPrize),
            RANK_9_ETOILE_PLUS_WINNERS = draw.Rank9EtoilePlusWinners,
            RANK_9_ETOILE_PLUS_PRIZE = ToDouble(draw.Rank9EtoilePlusPrize),
            RANK_10_ETOILE_PLUS_WINNERS = draw.Rank10EtoilePlusWinners,
            RANK_10_ETOILE_PLUS_PRIZE = ToDouble(draw.Rank10EtoilePlusPrize)
        };

    public static Draw ToDrawModel(this T_DRAW tDraw) => new Draw
    {
        YearDrawNumber = tDraw.YEAR_DRAW_NUMBER,
        DrawDate = tDraw.DRAW_DATE,
        Ball1 = tDraw.BALL_ONE,
        Ball2 = tDraw.BALL_TWO,
        Ball3 = tDraw.BALL_THREE,
        Ball4 = tDraw.BALL_FOUR,
        Ball5 = tDraw.BALL_FIVE,
        Star1 = tDraw.STAR_ONE,
        Star2 = tDraw.STAR_TWO,
        DrawNumberInCycle = StringHelpers.ParseNullableInt(tDraw.DRAW_NUMBER_IN_CYCLE)
    };
}

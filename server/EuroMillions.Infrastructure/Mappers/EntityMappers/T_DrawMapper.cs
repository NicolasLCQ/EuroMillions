using System.Linq.Expressions;

using EuroMillions.Application.Models;
using EuroMillions.Infrastructure.Entities;

namespace EuroMillions.Infrastructure.Mappers.EntityMappers;

public static class T_DrawMapper
{
    public static Expression<Func<T_DRAW, MinimalDrawModel>> ToMinimalDrawModelExpression() =>
        draw => new MinimalDrawModel
        {
            Ball1 = draw.BALL_ONE,
            Ball2 = draw.BALL_TWO,
            Ball3 = draw.BALL_THREE,
            Ball4 = draw.BALL_FOUR,
            Ball5 = draw.BALL_FIVE,
            Star1 = draw.STAR_ONE,
            Star2 = draw.STAR_TWO
        };

    public static DrawSummaryModel ToDrawSummaryModel(this T_DRAW tDraw) => new DrawSummaryModel
    {
        DrawNumber = tDraw.T_DRAW_INFORMATION?.YEAR_DRAW_NUMBER ?? 0,
        DrawDate = tDraw.T_DRAW_INFORMATION?.DRAW_DATE ?? default,
        Ball1 = tDraw.BALL_ONE,
        Ball2 = tDraw.BALL_TWO,
        Ball3 = tDraw.BALL_THREE,
        Ball4 = tDraw.BALL_FOUR,
        Ball5 = tDraw.BALL_FIVE,
        Star1 = tDraw.STAR_ONE,
        Star2 = tDraw.STAR_TWO,
        JokerPlusNumber = tDraw.T_DRAW_ADDITIONAL_GAME?.JOKER_PLUS_NUMBER,
        MyMillionNumber = tDraw.T_DRAW_ADDITIONAL_GAME?.MY_MILLION_NUMBER,
        ExceptionalEuroMillionsDrawNumber = tDraw.T_DRAW_ADDITIONAL_GAME?.EXCEPTIONAL_EURO_MILLIONS_DRAW_NUMBER,
        // T_DRAW_WINNER n'est nul que par definition de la base de donnée.
        Winners = tDraw.T_DRAW_WINNER!.ToDrawWinners()
    };

    public static T_DRAW ToDrawEntity(this Draw draw) =>
        new T_DRAW
        {
            BALL_ONE = draw.Ball1,
            BALL_TWO = draw.Ball2,
            BALL_THREE = draw.Ball3,
            BALL_FOUR = draw.Ball4,
            BALL_FIVE = draw.Ball5,
            STAR_ONE = draw.Star1,
            STAR_TWO = draw.Star2,
            WINNING_BALLS_IN_ASCENDING_ORDER = draw.WinningBallsInAscendingOrder,
            WINNING_STARS_IN_ASCENDING_ORDER = draw.WinningStarsInAscendingOrder,
            T_DRAW_INFORMATION
                = new T_DRAW_INFORMATION
                {
                    YEAR_DRAW_NUMBER = draw.DrawInformation.YearDrawNumber,
                    DRAW_DATE = draw.DrawInformation.DrawDate,
                    DRAW_DAY = draw.DrawInformation.DrawDay,
                    FORCLUSION_DATE = draw.DrawInformation.ForclusionDate,
                    DRAW_NUMBER_IN_CYCLE = draw.DrawInformation.DrawNumberInCycle
                },
            T_DRAW_ADDITIONAL_GAME
                = new T_DRAW_ADDITIONAL_GAME
                {
                    JOKER_PLUS_NUMBER = draw.AdditionalGame.JokerPlusNumber,
                    MY_MILLION_NUMBER = draw.AdditionalGame.MyMillionNumber,
                    EXCEPTIONAL_EURO_MILLIONS_DRAW_NUMBER = draw.AdditionalGame.ExceptionalEuroMillionsDrawNumber
                },
            T_DRAW_WINNER = new T_DRAW_WINNER
            {
                RANK_1_EURO_MILLIONS_WINNERS_FRANCE = draw.Winners.Rank1EuroMillionsWinnersFrance,
                RANK_1_EURO_MILLIONS_WINNERS_EUROPE = draw.Winners.Rank1EuroMillionsWinnersEurope,
                RANK_1_EURO_MILLIONS_PRIZE = (double)draw.Winners.Rank1EuroMillionsPrize,
                RANK_2_EURO_MILLIONS_WINNERS_FRANCE = draw.Winners.Rank2EuroMillionsWinnersFrance,
                RANK_2_EURO_MILLIONS_WINNERS_EUROPE = draw.Winners.Rank2EuroMillionsWinnersEurope,
                RANK_2_EURO_MILLIONS_PRIZE = (double)draw.Winners.Rank2EuroMillionsPrize,
                RANK_3_EURO_MILLIONS_WINNERS_FRANCE = draw.Winners.Rank3EuroMillionsWinnersFrance,
                RANK_3_EURO_MILLIONS_WINNERS_EUROPE = draw.Winners.Rank3EuroMillionsWinnersEurope,
                RANK_3_EURO_MILLIONS_PRIZE = (double)draw.Winners.Rank3EuroMillionsPrize,
                RANK_4_EURO_MILLIONS_WINNERS_FRANCE = draw.Winners.Rank4EuroMillionsWinnersFrance,
                RANK_4_EURO_MILLIONS_WINNERS_EUROPE = draw.Winners.Rank4EuroMillionsWinnersEurope,
                RANK_4_EURO_MILLIONS_PRIZE = (double)draw.Winners.Rank4EuroMillionsPrize,
                RANK_5_EURO_MILLIONS_WINNERS_FRANCE = draw.Winners.Rank5EuroMillionsWinnersFrance,
                RANK_5_EURO_MILLIONS_WINNERS_EUROPE = draw.Winners.Rank5EuroMillionsWinnersEurope,
                RANK_5_EURO_MILLIONS_PRIZE = (double)draw.Winners.Rank5EuroMillionsPrize,
                RANK_6_EURO_MILLIONS_WINNERS_FRANCE = draw.Winners.Rank6EuroMillionsWinnersFrance,
                RANK_6_EURO_MILLIONS_WINNERS_EUROPE = draw.Winners.Rank6EuroMillionsWinnersEurope,
                RANK_6_EURO_MILLIONS_PRIZE = (double)draw.Winners.Rank6EuroMillionsPrize,
                RANK_7_EURO_MILLIONS_WINNERS_FRANCE = draw.Winners.Rank7EuroMillionsWinnersFrance,
                RANK_7_EURO_MILLIONS_WINNERS_EUROPE = draw.Winners.Rank7EuroMillionsWinnersEurope,
                RANK_7_EURO_MILLIONS_PRIZE = (double)draw.Winners.Rank7EuroMillionsPrize,
                RANK_8_EURO_MILLIONS_WINNERS_FRANCE = draw.Winners.Rank8EuroMillionsWinnersFrance,
                RANK_8_EURO_MILLIONS_WINNERS_EUROPE = draw.Winners.Rank8EuroMillionsWinnersEurope,
                RANK_8_EURO_MILLIONS_PRIZE = (double)draw.Winners.Rank8EuroMillionsPrize,
                RANK_9_EURO_MILLIONS_WINNERS_FRANCE = draw.Winners.Rank9EuroMillionsWinnersFrance,
                RANK_9_EURO_MILLIONS_WINNERS_EUROPE = draw.Winners.Rank9EuroMillionsWinnersEurope,
                RANK_9_EURO_MILLIONS_PRIZE = (double)draw.Winners.Rank9EuroMillionsPrize,
                RANK_10_EURO_MILLIONS_WINNERS_FRANCE = draw.Winners.Rank10EuroMillionsWinnersFrance,
                RANK_10_EURO_MILLIONS_WINNERS_EUROPE = draw.Winners.Rank10EuroMillionsWinnersEurope,
                RANK_10_EURO_MILLIONS_PRIZE = (double)draw.Winners.Rank10EuroMillionsPrize,
                RANK_11_EURO_MILLIONS_WINNERS_FRANCE = draw.Winners.Rank11EuroMillionsWinnersFrance,
                RANK_11_EURO_MILLIONS_WINNERS_EUROPE = draw.Winners.Rank11EuroMillionsWinnersEurope,
                RANK_11_EURO_MILLIONS_PRIZE = (double)draw.Winners.Rank11EuroMillionsPrize,
                RANK_12_EURO_MILLIONS_WINNERS_FRANCE = draw.Winners.Rank12EuroMillionsWinnersFrance,
                RANK_12_EURO_MILLIONS_WINNERS_EUROPE = draw.Winners.Rank12EuroMillionsWinnersEurope,
                RANK_12_EURO_MILLIONS_PRIZE = (double)draw.Winners.Rank12EuroMillionsPrize,
                RANK_13_EURO_MILLIONS_WINNERS_FRANCE = draw.Winners.Rank13EuroMillionsWinnersFrance,
                RANK_13_EURO_MILLIONS_WINNERS_EUROPE = draw.Winners.Rank13EuroMillionsWinnersEurope,
                RANK_13_EURO_MILLIONS_PRIZE = (double)draw.Winners.Rank13EuroMillionsPrize,
                RANK_1_ETOILE_PLUS_WINNERS = draw.Winners.Rank1EtoilePlusWinners,
                RANK_1_ETOILE_PLUS_PRIZE = (double)draw.Winners.Rank1EtoilePlusPrize,
                RANK_2_ETOILE_PLUS_WINNERS = draw.Winners.Rank2EtoilePlusWinners,
                RANK_2_ETOILE_PLUS_PRIZE = (double)draw.Winners.Rank2EtoilePlusPrize,
                RANK_3_ETOILE_PLUS_WINNERS = draw.Winners.Rank3EtoilePlusWinners,
                RANK_3_ETOILE_PLUS_PRIZE = (double)draw.Winners.Rank3EtoilePlusPrize,
                RANK_4_ETOILE_PLUS_WINNERS = draw.Winners.Rank4EtoilePlusWinners,
                RANK_4_ETOILE_PLUS_PRIZE = (double)draw.Winners.Rank4EtoilePlusPrize,
                RANK_5_ETOILE_PLUS_WINNERS = draw.Winners.Rank5EtoilePlusWinners,
                RANK_5_ETOILE_PLUS_PRIZE = (double)draw.Winners.Rank5EtoilePlusPrize,
                RANK_6_ETOILE_PLUS_WINNERS = draw.Winners.Rank6EtoilePlusWinners,
                RANK_6_ETOILE_PLUS_PRIZE = (double)draw.Winners.Rank6EtoilePlusPrize,
                RANK_7_ETOILE_PLUS_WINNERS = draw.Winners.Rank7EtoilePlusWinners,
                RANK_7_ETOILE_PLUS_PRIZE = (double)draw.Winners.Rank7EtoilePlusPrize,
                RANK_8_ETOILE_PLUS_WINNERS = draw.Winners.Rank8EtoilePlusWinners,
                RANK_8_ETOILE_PLUS_PRIZE = (double)draw.Winners.Rank8EtoilePlusPrize,
                RANK_9_ETOILE_PLUS_WINNERS = draw.Winners.Rank9EtoilePlusWinners,
                RANK_9_ETOILE_PLUS_PRIZE = (double)draw.Winners.Rank9EtoilePlusPrize,
                RANK_10_ETOILE_PLUS_WINNERS = draw.Winners.Rank10EtoilePlusWinners,
                RANK_10_ETOILE_PLUS_PRIZE = (double)draw.Winners.Rank10EtoilePlusPrize
            }
        };

    private static DrawWinners ToDrawWinners(this T_DRAW_WINNER winner) => new DrawWinners
    {
        Rank1EuroMillionsWinnersFrance = winner.RANK_1_EURO_MILLIONS_WINNERS_FRANCE,
        Rank1EuroMillionsWinnersEurope = winner.RANK_1_EURO_MILLIONS_WINNERS_EUROPE,
        Rank1EuroMillionsPrize = (decimal)winner.RANK_1_EURO_MILLIONS_PRIZE,
        Rank2EuroMillionsWinnersFrance = winner.RANK_2_EURO_MILLIONS_WINNERS_FRANCE,
        Rank2EuroMillionsWinnersEurope = winner.RANK_2_EURO_MILLIONS_WINNERS_EUROPE,
        Rank2EuroMillionsPrize = (decimal)winner.RANK_2_EURO_MILLIONS_PRIZE,
        Rank3EuroMillionsWinnersFrance = winner.RANK_3_EURO_MILLIONS_WINNERS_FRANCE,
        Rank3EuroMillionsWinnersEurope = winner.RANK_3_EURO_MILLIONS_WINNERS_EUROPE,
        Rank3EuroMillionsPrize = (decimal)winner.RANK_3_EURO_MILLIONS_PRIZE,
        Rank4EuroMillionsWinnersFrance = winner.RANK_4_EURO_MILLIONS_WINNERS_FRANCE,
        Rank4EuroMillionsWinnersEurope = winner.RANK_4_EURO_MILLIONS_WINNERS_EUROPE,
        Rank4EuroMillionsPrize = (decimal)winner.RANK_4_EURO_MILLIONS_PRIZE,
        Rank5EuroMillionsWinnersFrance = winner.RANK_5_EURO_MILLIONS_WINNERS_FRANCE,
        Rank5EuroMillionsWinnersEurope = winner.RANK_5_EURO_MILLIONS_WINNERS_EUROPE,
        Rank5EuroMillionsPrize = (decimal)winner.RANK_5_EURO_MILLIONS_PRIZE,
        Rank6EuroMillionsWinnersFrance = winner.RANK_6_EURO_MILLIONS_WINNERS_FRANCE,
        Rank6EuroMillionsWinnersEurope = winner.RANK_6_EURO_MILLIONS_WINNERS_EUROPE,
        Rank6EuroMillionsPrize = (decimal)winner.RANK_6_EURO_MILLIONS_PRIZE,
        Rank7EuroMillionsWinnersFrance = winner.RANK_7_EURO_MILLIONS_WINNERS_FRANCE,
        Rank7EuroMillionsWinnersEurope = winner.RANK_7_EURO_MILLIONS_WINNERS_EUROPE,
        Rank7EuroMillionsPrize = (decimal)winner.RANK_7_EURO_MILLIONS_PRIZE,
        Rank8EuroMillionsWinnersFrance = winner.RANK_8_EURO_MILLIONS_WINNERS_FRANCE,
        Rank8EuroMillionsWinnersEurope = winner.RANK_8_EURO_MILLIONS_WINNERS_EUROPE,
        Rank8EuroMillionsPrize = (decimal)winner.RANK_8_EURO_MILLIONS_PRIZE,
        Rank9EuroMillionsWinnersFrance = winner.RANK_9_EURO_MILLIONS_WINNERS_FRANCE,
        Rank9EuroMillionsWinnersEurope = winner.RANK_9_EURO_MILLIONS_WINNERS_EUROPE,
        Rank9EuroMillionsPrize = (decimal)winner.RANK_9_EURO_MILLIONS_PRIZE,
        Rank10EuroMillionsWinnersFrance = winner.RANK_10_EURO_MILLIONS_WINNERS_FRANCE,
        Rank10EuroMillionsWinnersEurope = winner.RANK_10_EURO_MILLIONS_WINNERS_EUROPE,
        Rank10EuroMillionsPrize = (decimal)winner.RANK_10_EURO_MILLIONS_PRIZE,
        Rank11EuroMillionsWinnersFrance = winner.RANK_11_EURO_MILLIONS_WINNERS_FRANCE,
        Rank11EuroMillionsWinnersEurope = winner.RANK_11_EURO_MILLIONS_WINNERS_EUROPE,
        Rank11EuroMillionsPrize = (decimal)winner.RANK_11_EURO_MILLIONS_PRIZE,
        Rank12EuroMillionsWinnersFrance = winner.RANK_12_EURO_MILLIONS_WINNERS_FRANCE,
        Rank12EuroMillionsWinnersEurope = winner.RANK_12_EURO_MILLIONS_WINNERS_EUROPE,
        Rank12EuroMillionsPrize = (decimal)winner.RANK_12_EURO_MILLIONS_PRIZE,
        Rank13EuroMillionsWinnersFrance = winner.RANK_13_EURO_MILLIONS_WINNERS_FRANCE,
        Rank13EuroMillionsWinnersEurope = winner.RANK_13_EURO_MILLIONS_WINNERS_EUROPE,
        Rank13EuroMillionsPrize = (decimal)winner.RANK_13_EURO_MILLIONS_PRIZE,
        Rank1EtoilePlusWinners = winner.RANK_1_ETOILE_PLUS_WINNERS,
        Rank1EtoilePlusPrize = (decimal)winner.RANK_1_ETOILE_PLUS_PRIZE,
        Rank2EtoilePlusWinners = winner.RANK_2_ETOILE_PLUS_WINNERS,
        Rank2EtoilePlusPrize = (decimal)winner.RANK_2_ETOILE_PLUS_PRIZE,
        Rank3EtoilePlusWinners = winner.RANK_3_ETOILE_PLUS_WINNERS,
        Rank3EtoilePlusPrize = (decimal)winner.RANK_3_ETOILE_PLUS_PRIZE,
        Rank4EtoilePlusWinners = winner.RANK_4_ETOILE_PLUS_WINNERS,
        Rank4EtoilePlusPrize = (decimal)winner.RANK_4_ETOILE_PLUS_PRIZE,
        Rank5EtoilePlusWinners = winner.RANK_5_ETOILE_PLUS_WINNERS,
        Rank5EtoilePlusPrize = (decimal)winner.RANK_5_ETOILE_PLUS_PRIZE,
        Rank6EtoilePlusWinners = winner.RANK_6_ETOILE_PLUS_WINNERS,
        Rank6EtoilePlusPrize = (decimal)winner.RANK_6_ETOILE_PLUS_PRIZE,
        Rank7EtoilePlusWinners = winner.RANK_7_ETOILE_PLUS_WINNERS,
        Rank7EtoilePlusPrize = (decimal)winner.RANK_7_ETOILE_PLUS_PRIZE,
        Rank8EtoilePlusWinners = winner.RANK_8_ETOILE_PLUS_WINNERS,
        Rank8EtoilePlusPrize = (decimal)winner.RANK_8_ETOILE_PLUS_PRIZE,
        Rank9EtoilePlusWinners = winner.RANK_9_ETOILE_PLUS_WINNERS,
        Rank9EtoilePlusPrize = (decimal)winner.RANK_9_ETOILE_PLUS_PRIZE,
        Rank10EtoilePlusWinners = winner.RANK_10_ETOILE_PLUS_WINNERS,
        Rank10EtoilePlusPrize = (decimal)winner.RANK_10_ETOILE_PLUS_PRIZE
    };
}

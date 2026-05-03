using EuroMillions.Application.Models;
using EuroMillions.Infrastructure.Entities;

namespace EuroMillions.Infrastructure.Mappers.EntityMappers;

public static class T_DrawMapper
{
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
        Star2 = tDraw.STAR_TWO
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
            T_DRAW_INFORMATION = new T_DRAW_INFORMATION
                {
                    YEAR_DRAW_NUMBER = draw.DrawInformation.YearDrawNumber,
                    DRAW_DATE = draw.DrawInformation.DrawDate,
                    DRAW_DAY = draw.DrawInformation.DrawDay,
                    FORCLUSION_DATE = draw.DrawInformation.ForclusionDate,
                    DRAW_NUMBER_IN_CYCLE = draw.DrawInformation.DrawNumberInCycle,
                },
            T_DRAW_ADDITIONAL_GAME = new T_DRAW_ADDITIONAL_GAME
                {
                    JOKER_PLUS_NUMBER = draw.AdditionalGame.JokerPlusNumber,
                    MY_MILLION_NUMBER = draw.AdditionalGame.MyMillionNumber,
                    EXCEPTIONAL_EURO_MILLIONS_DRAW_NUMBER = draw.AdditionalGame.ExceptionalEuroMillionsDrawNumber
                },
            T_DRAW_WINNER = new T_DRAW_WINNER
                {
                    CURRENCY = draw.Winners.Currency,
                    RANK_1_EURO_MILLIONS_WINNERS_FRANCE = draw.Winners.Rank1EuroMillionsWinnersFrance,
                    RANK_1_EURO_MILLIONS_WINNERS_EUROPE = draw.Winners.Rank1EuroMillionsWinnersEurope,
                    RANK_1_EURO_MILLIONS_PRIZE = (double?)draw.Winners.Rank1EuroMillionsPrize,
                    RANK_2_EURO_MILLIONS_WINNERS_FRANCE = draw.Winners.Rank2EuroMillionsWinnersFrance,
                    RANK_2_EURO_MILLIONS_WINNERS_EUROPE = draw.Winners.Rank2EuroMillionsWinnersEurope,
                    RANK_2_EURO_MILLIONS_PRIZE = (double?)draw.Winners.Rank2EuroMillionsPrize,
                    RANK_3_EURO_MILLIONS_WINNERS_FRANCE = draw.Winners.Rank3EuroMillionsWinnersFrance,
                    RANK_3_EURO_MILLIONS_WINNERS_EUROPE = draw.Winners.Rank3EuroMillionsWinnersEurope,
                    RANK_3_EURO_MILLIONS_PRIZE = (double?)draw.Winners.Rank3EuroMillionsPrize,
                    RANK_4_EURO_MILLIONS_WINNERS_FRANCE = draw.Winners.Rank4EuroMillionsWinnersFrance,
                    RANK_4_EURO_MILLIONS_WINNERS_EUROPE = draw.Winners.Rank4EuroMillionsWinnersEurope,
                    RANK_4_EURO_MILLIONS_PRIZE = (double?)draw.Winners.Rank4EuroMillionsPrize,
                    RANK_5_EURO_MILLIONS_WINNERS_FRANCE = draw.Winners.Rank5EuroMillionsWinnersFrance,
                    RANK_5_EURO_MILLIONS_WINNERS_EUROPE = draw.Winners.Rank5EuroMillionsWinnersEurope,
                    RANK_5_EURO_MILLIONS_PRIZE = (double?)draw.Winners.Rank5EuroMillionsPrize,
                    RANK_6_EURO_MILLIONS_WINNERS_FRANCE = draw.Winners.Rank6EuroMillionsWinnersFrance,
                    RANK_6_EURO_MILLIONS_WINNERS_EUROPE = draw.Winners.Rank6EuroMillionsWinnersEurope,
                    RANK_6_EURO_MILLIONS_PRIZE = (double?)draw.Winners.Rank6EuroMillionsPrize,
                    RANK_7_EURO_MILLIONS_WINNERS_FRANCE = draw.Winners.Rank7EuroMillionsWinnersFrance,
                    RANK_7_EURO_MILLIONS_WINNERS_EUROPE = draw.Winners.Rank7EuroMillionsWinnersEurope,
                    RANK_7_EURO_MILLIONS_PRIZE = (double?)draw.Winners.Rank7EuroMillionsPrize,
                    RANK_8_EURO_MILLIONS_WINNERS_FRANCE = draw.Winners.Rank8EuroMillionsWinnersFrance,
                    RANK_8_EURO_MILLIONS_WINNERS_EUROPE = draw.Winners.Rank8EuroMillionsWinnersEurope,
                    RANK_8_EURO_MILLIONS_PRIZE = (double?)draw.Winners.Rank8EuroMillionsPrize,
                    RANK_9_EURO_MILLIONS_WINNERS_FRANCE = draw.Winners.Rank9EuroMillionsWinnersFrance,
                    RANK_9_EURO_MILLIONS_WINNERS_EUROPE = draw.Winners.Rank9EuroMillionsWinnersEurope,
                    RANK_9_EURO_MILLIONS_PRIZE = (double?)draw.Winners.Rank9EuroMillionsPrize,
                    RANK_10_EURO_MILLIONS_WINNERS_FRANCE = draw.Winners.Rank10EuroMillionsWinnersFrance,
                    RANK_10_EURO_MILLIONS_WINNERS_EUROPE = draw.Winners.Rank10EuroMillionsWinnersEurope,
                    RANK_10_EURO_MILLIONS_PRIZE = (double?)draw.Winners.Rank10EuroMillionsPrize,
                    RANK_11_EURO_MILLIONS_WINNERS_FRANCE = draw.Winners.Rank11EuroMillionsWinnersFrance,
                    RANK_11_EURO_MILLIONS_WINNERS_EUROPE = draw.Winners.Rank11EuroMillionsWinnersEurope,
                    RANK_11_EURO_MILLIONS_PRIZE = (double?)draw.Winners.Rank11EuroMillionsPrize,
                    RANK_12_EURO_MILLIONS_WINNERS_FRANCE = draw.Winners.Rank12EuroMillionsWinnersFrance,
                    RANK_12_EURO_MILLIONS_WINNERS_EUROPE = draw.Winners.Rank12EuroMillionsWinnersEurope,
                    RANK_12_EURO_MILLIONS_PRIZE = (double?)draw.Winners.Rank12EuroMillionsPrize,
                    RANK_13_EURO_MILLIONS_WINNERS_FRANCE = draw.Winners.Rank13EuroMillionsWinnersFrance,
                    RANK_13_EURO_MILLIONS_WINNERS_EUROPE = draw.Winners.Rank13EuroMillionsWinnersEurope,
                    RANK_13_EURO_MILLIONS_PRIZE = (double?)draw.Winners.Rank13EuroMillionsPrize,
                    RANK_1_ETOILE_PLUS_WINNERS = draw.Winners.Rank1EtoilePlusWinners,
                    RANK_1_ETOILE_PLUS_PRIZE = (double?)draw.Winners.Rank1EtoilePlusPrize,
                    RANK_2_ETOILE_PLUS_WINNERS = draw.Winners.Rank2EtoilePlusWinners,
                    RANK_2_ETOILE_PLUS_PRIZE = (double?)draw.Winners.Rank2EtoilePlusPrize,
                    RANK_3_ETOILE_PLUS_WINNERS = draw.Winners.Rank3EtoilePlusWinners,
                    RANK_3_ETOILE_PLUS_PRIZE = (double?)draw.Winners.Rank3EtoilePlusPrize,
                    RANK_4_ETOILE_PLUS_WINNERS = draw.Winners.Rank4EtoilePlusWinners,
                    RANK_4_ETOILE_PLUS_PRIZE = (double?)draw.Winners.Rank4EtoilePlusPrize,
                    RANK_5_ETOILE_PLUS_WINNERS = draw.Winners.Rank5EtoilePlusWinners,
                    RANK_5_ETOILE_PLUS_PRIZE = (double?)draw.Winners.Rank5EtoilePlusPrize,
                    RANK_6_ETOILE_PLUS_WINNERS = draw.Winners.Rank6EtoilePlusWinners,
                    RANK_6_ETOILE_PLUS_PRIZE = (double?)draw.Winners.Rank6EtoilePlusPrize,
                    RANK_7_ETOILE_PLUS_WINNERS = draw.Winners.Rank7EtoilePlusWinners,
                    RANK_7_ETOILE_PLUS_PRIZE = (double?)draw.Winners.Rank7EtoilePlusPrize,
                    RANK_8_ETOILE_PLUS_WINNERS = draw.Winners.Rank8EtoilePlusWinners,
                    RANK_8_ETOILE_PLUS_PRIZE = (double?)draw.Winners.Rank8EtoilePlusPrize,
                    RANK_9_ETOILE_PLUS_WINNERS = draw.Winners.Rank9EtoilePlusWinners,
                    RANK_9_ETOILE_PLUS_PRIZE = (double?)draw.Winners.Rank9EtoilePlusPrize,
                    RANK_10_ETOILE_PLUS_WINNERS = draw.Winners.Rank10EtoilePlusWinners,
                    RANK_10_ETOILE_PLUS_PRIZE = (double?)draw.Winners.Rank10EtoilePlusPrize
                }
        };

    public static Draw ToDrawModel(this T_DRAW tDraw) => new Draw
    {
        Ball1 = tDraw.BALL_ONE,
        Ball2 = tDraw.BALL_TWO,
        Ball3 = tDraw.BALL_THREE,
        Ball4 = tDraw.BALL_FOUR,
        Ball5 = tDraw.BALL_FIVE,
        Star1 = tDraw.STAR_ONE,
        Star2 = tDraw.STAR_TWO,
        WinningBallsInAscendingOrder = tDraw.WINNING_BALLS_IN_ASCENDING_ORDER,
        WinningStarsInAscendingOrder = tDraw.WINNING_STARS_IN_ASCENDING_ORDER,
        DrawInformation = tDraw.T_DRAW_INFORMATION is null
            ? new DrawInformation()
            : new DrawInformation
            {
                YearDrawNumber = tDraw.T_DRAW_INFORMATION.YEAR_DRAW_NUMBER,
                DrawDate = tDraw.T_DRAW_INFORMATION.DRAW_DATE,
                DrawDay = tDraw.T_DRAW_INFORMATION.DRAW_DAY,
                ForclusionDate = tDraw.T_DRAW_INFORMATION.FORCLUSION_DATE,
                DrawNumberInCycle = tDraw.T_DRAW_INFORMATION.DRAW_NUMBER_IN_CYCLE,
            },
        AdditionalGame = tDraw.T_DRAW_ADDITIONAL_GAME is null
            ? new DrawAdditionalGame()
            : new DrawAdditionalGame
            {
                JokerPlusNumber = tDraw.T_DRAW_ADDITIONAL_GAME.JOKER_PLUS_NUMBER,
                MyMillionNumber = tDraw.T_DRAW_ADDITIONAL_GAME.MY_MILLION_NUMBER,
                ExceptionalEuroMillionsDrawNumber = tDraw.T_DRAW_ADDITIONAL_GAME.EXCEPTIONAL_EURO_MILLIONS_DRAW_NUMBER
            },
        Winners = tDraw.T_DRAW_WINNER is null
            ? new DrawWinners()
            : new DrawWinners
            {
                Currency = tDraw.T_DRAW_WINNER.CURRENCY,
                Rank1EuroMillionsWinnersFrance = tDraw.T_DRAW_WINNER.RANK_1_EURO_MILLIONS_WINNERS_FRANCE,
                Rank1EuroMillionsWinnersEurope = tDraw.T_DRAW_WINNER.RANK_1_EURO_MILLIONS_WINNERS_EUROPE,
                Rank1EuroMillionsPrize = (decimal?)tDraw.T_DRAW_WINNER.RANK_1_EURO_MILLIONS_PRIZE,
                Rank2EuroMillionsWinnersFrance = tDraw.T_DRAW_WINNER.RANK_2_EURO_MILLIONS_WINNERS_FRANCE,
                Rank2EuroMillionsWinnersEurope = tDraw.T_DRAW_WINNER.RANK_2_EURO_MILLIONS_WINNERS_EUROPE,
                Rank2EuroMillionsPrize = (decimal?)tDraw.T_DRAW_WINNER.RANK_2_EURO_MILLIONS_PRIZE,
                Rank3EuroMillionsWinnersFrance = tDraw.T_DRAW_WINNER.RANK_3_EURO_MILLIONS_WINNERS_FRANCE,
                Rank3EuroMillionsWinnersEurope = tDraw.T_DRAW_WINNER.RANK_3_EURO_MILLIONS_WINNERS_EUROPE,
                Rank3EuroMillionsPrize = (decimal?)tDraw.T_DRAW_WINNER.RANK_3_EURO_MILLIONS_PRIZE,
                Rank4EuroMillionsWinnersFrance = tDraw.T_DRAW_WINNER.RANK_4_EURO_MILLIONS_WINNERS_FRANCE,
                Rank4EuroMillionsWinnersEurope = tDraw.T_DRAW_WINNER.RANK_4_EURO_MILLIONS_WINNERS_EUROPE,
                Rank4EuroMillionsPrize = (decimal?)tDraw.T_DRAW_WINNER.RANK_4_EURO_MILLIONS_PRIZE,
                Rank5EuroMillionsWinnersFrance = tDraw.T_DRAW_WINNER.RANK_5_EURO_MILLIONS_WINNERS_FRANCE,
                Rank5EuroMillionsWinnersEurope = tDraw.T_DRAW_WINNER.RANK_5_EURO_MILLIONS_WINNERS_EUROPE,
                Rank5EuroMillionsPrize = (decimal?)tDraw.T_DRAW_WINNER.RANK_5_EURO_MILLIONS_PRIZE,
                Rank6EuroMillionsWinnersFrance = tDraw.T_DRAW_WINNER.RANK_6_EURO_MILLIONS_WINNERS_FRANCE,
                Rank6EuroMillionsWinnersEurope = tDraw.T_DRAW_WINNER.RANK_6_EURO_MILLIONS_WINNERS_EUROPE,
                Rank6EuroMillionsPrize = (decimal?)tDraw.T_DRAW_WINNER.RANK_6_EURO_MILLIONS_PRIZE,
                Rank7EuroMillionsWinnersFrance = tDraw.T_DRAW_WINNER.RANK_7_EURO_MILLIONS_WINNERS_FRANCE,
                Rank7EuroMillionsWinnersEurope = tDraw.T_DRAW_WINNER.RANK_7_EURO_MILLIONS_WINNERS_EUROPE,
                Rank7EuroMillionsPrize = (decimal?)tDraw.T_DRAW_WINNER.RANK_7_EURO_MILLIONS_PRIZE,
                Rank8EuroMillionsWinnersFrance = tDraw.T_DRAW_WINNER.RANK_8_EURO_MILLIONS_WINNERS_FRANCE,
                Rank8EuroMillionsWinnersEurope = tDraw.T_DRAW_WINNER.RANK_8_EURO_MILLIONS_WINNERS_EUROPE,
                Rank8EuroMillionsPrize = (decimal?)tDraw.T_DRAW_WINNER.RANK_8_EURO_MILLIONS_PRIZE,
                Rank9EuroMillionsWinnersFrance = tDraw.T_DRAW_WINNER.RANK_9_EURO_MILLIONS_WINNERS_FRANCE,
                Rank9EuroMillionsWinnersEurope = tDraw.T_DRAW_WINNER.RANK_9_EURO_MILLIONS_WINNERS_EUROPE,
                Rank9EuroMillionsPrize = (decimal?)tDraw.T_DRAW_WINNER.RANK_9_EURO_MILLIONS_PRIZE,
                Rank10EuroMillionsWinnersFrance = tDraw.T_DRAW_WINNER.RANK_10_EURO_MILLIONS_WINNERS_FRANCE,
                Rank10EuroMillionsWinnersEurope = tDraw.T_DRAW_WINNER.RANK_10_EURO_MILLIONS_WINNERS_EUROPE,
                Rank10EuroMillionsPrize = (decimal?)tDraw.T_DRAW_WINNER.RANK_10_EURO_MILLIONS_PRIZE,
                Rank11EuroMillionsWinnersFrance = tDraw.T_DRAW_WINNER.RANK_11_EURO_MILLIONS_WINNERS_FRANCE,
                Rank11EuroMillionsWinnersEurope = tDraw.T_DRAW_WINNER.RANK_11_EURO_MILLIONS_WINNERS_EUROPE,
                Rank11EuroMillionsPrize = (decimal?)tDraw.T_DRAW_WINNER.RANK_11_EURO_MILLIONS_PRIZE,
                Rank12EuroMillionsWinnersFrance = tDraw.T_DRAW_WINNER.RANK_12_EURO_MILLIONS_WINNERS_FRANCE,
                Rank12EuroMillionsWinnersEurope = tDraw.T_DRAW_WINNER.RANK_12_EURO_MILLIONS_WINNERS_EUROPE,
                Rank12EuroMillionsPrize = (decimal?)tDraw.T_DRAW_WINNER.RANK_12_EURO_MILLIONS_PRIZE,
                Rank13EuroMillionsWinnersFrance = tDraw.T_DRAW_WINNER.RANK_13_EURO_MILLIONS_WINNERS_FRANCE,
                Rank13EuroMillionsWinnersEurope = tDraw.T_DRAW_WINNER.RANK_13_EURO_MILLIONS_WINNERS_EUROPE,
                Rank13EuroMillionsPrize = (decimal?)tDraw.T_DRAW_WINNER.RANK_13_EURO_MILLIONS_PRIZE,
                Rank1EtoilePlusWinners = tDraw.T_DRAW_WINNER.RANK_1_ETOILE_PLUS_WINNERS,
                Rank1EtoilePlusPrize = (decimal?)tDraw.T_DRAW_WINNER.RANK_1_ETOILE_PLUS_PRIZE,
                Rank2EtoilePlusWinners = tDraw.T_DRAW_WINNER.RANK_2_ETOILE_PLUS_WINNERS,
                Rank2EtoilePlusPrize = (decimal?)tDraw.T_DRAW_WINNER.RANK_2_ETOILE_PLUS_PRIZE,
                Rank3EtoilePlusWinners = tDraw.T_DRAW_WINNER.RANK_3_ETOILE_PLUS_WINNERS,
                Rank3EtoilePlusPrize = (decimal?)tDraw.T_DRAW_WINNER.RANK_3_ETOILE_PLUS_PRIZE,
                Rank4EtoilePlusWinners = tDraw.T_DRAW_WINNER.RANK_4_ETOILE_PLUS_WINNERS,
                Rank4EtoilePlusPrize = (decimal?)tDraw.T_DRAW_WINNER.RANK_4_ETOILE_PLUS_PRIZE,
                Rank5EtoilePlusWinners = tDraw.T_DRAW_WINNER.RANK_5_ETOILE_PLUS_WINNERS,
                Rank5EtoilePlusPrize = (decimal?)tDraw.T_DRAW_WINNER.RANK_5_ETOILE_PLUS_PRIZE,
                Rank6EtoilePlusWinners = tDraw.T_DRAW_WINNER.RANK_6_ETOILE_PLUS_WINNERS,
                Rank6EtoilePlusPrize = (decimal?)tDraw.T_DRAW_WINNER.RANK_6_ETOILE_PLUS_PRIZE,
                Rank7EtoilePlusWinners = tDraw.T_DRAW_WINNER.RANK_7_ETOILE_PLUS_WINNERS,
                Rank7EtoilePlusPrize = (decimal?)tDraw.T_DRAW_WINNER.RANK_7_ETOILE_PLUS_PRIZE,
                Rank8EtoilePlusWinners = tDraw.T_DRAW_WINNER.RANK_8_ETOILE_PLUS_WINNERS,
                Rank8EtoilePlusPrize = (decimal?)tDraw.T_DRAW_WINNER.RANK_8_ETOILE_PLUS_PRIZE,
                Rank9EtoilePlusWinners = tDraw.T_DRAW_WINNER.RANK_9_ETOILE_PLUS_WINNERS,
                Rank9EtoilePlusPrize = (decimal?)tDraw.T_DRAW_WINNER.RANK_9_ETOILE_PLUS_PRIZE,
                Rank10EtoilePlusWinners = tDraw.T_DRAW_WINNER.RANK_10_ETOILE_PLUS_WINNERS,
                Rank10EtoilePlusPrize = (decimal?)tDraw.T_DRAW_WINNER.RANK_10_ETOILE_PLUS_PRIZE
            }
    };
}

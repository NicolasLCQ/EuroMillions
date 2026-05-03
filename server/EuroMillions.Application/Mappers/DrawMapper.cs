using EuroMillions.Application.Models;
using EuroMillions.Application.Models.Upload;

namespace EuroMillions.Application.Mappers;

public static class DrawMapper
{
    public static RejectedDraw ToRejectedDraw(this Draw draw, string reason) =>
        new RejectedDraw
        {
            WinningBallsInAscendingOrder = draw.WinningBallsInAscendingOrder,
            WinningStarsInAscendingOrder = draw.WinningStarsInAscendingOrder,
            Ball1 = draw.Ball1,
            Ball2 = draw.Ball2,
            Ball3 = draw.Ball3,
            Ball4 = draw.Ball4,
            Ball5 = draw.Ball5,
            Star1 = draw.Star1,
            Star2 = draw.Star2,
            DrawInformation = draw.DrawInformation is null
                ? null
                : new DrawInformation
                {
                    YearDrawNumber = draw.DrawInformation.YearDrawNumber,
                    DrawDate = draw.DrawInformation.DrawDate,
                    DrawDay = draw.DrawInformation.DrawDay,
                    ForclusionDate = draw.DrawInformation.ForclusionDate,
                    DrawNumberInCycle = draw.DrawInformation.DrawNumberInCycle,
                },
            AdditionalGame = draw.AdditionalGame is null
                ? null
                : new DrawAdditionalGame
                {
                    JokerPlusNumber = draw.AdditionalGame.JokerPlusNumber,
                    MyMillionNumber = draw.AdditionalGame.MyMillionNumber,
                    ExceptionalEuroMillionsDrawNumber = draw.AdditionalGame.ExceptionalEuroMillionsDrawNumber
                },
            Winners = new DrawWinners
            {
                Currency = draw.Winners.Currency,
                Rank1EuroMillionsWinnersFrance = draw.Winners.Rank1EuroMillionsWinnersFrance,
                Rank1EuroMillionsWinnersEurope = draw.Winners.Rank1EuroMillionsWinnersEurope,
                Rank1EuroMillionsPrize = draw.Winners.Rank1EuroMillionsPrize,
                Rank2EuroMillionsWinnersFrance = draw.Winners.Rank2EuroMillionsWinnersFrance,
                Rank2EuroMillionsWinnersEurope = draw.Winners.Rank2EuroMillionsWinnersEurope,
                Rank2EuroMillionsPrize = draw.Winners.Rank2EuroMillionsPrize,
                Rank3EuroMillionsWinnersFrance = draw.Winners.Rank3EuroMillionsWinnersFrance,
                Rank3EuroMillionsWinnersEurope = draw.Winners.Rank3EuroMillionsWinnersEurope,
                Rank3EuroMillionsPrize = draw.Winners.Rank3EuroMillionsPrize,
                Rank4EuroMillionsWinnersFrance = draw.Winners.Rank4EuroMillionsWinnersFrance,
                Rank4EuroMillionsWinnersEurope = draw.Winners.Rank4EuroMillionsWinnersEurope,
                Rank4EuroMillionsPrize = draw.Winners.Rank4EuroMillionsPrize,
                Rank5EuroMillionsWinnersFrance = draw.Winners.Rank5EuroMillionsWinnersFrance,
                Rank5EuroMillionsWinnersEurope = draw.Winners.Rank5EuroMillionsWinnersEurope,
                Rank5EuroMillionsPrize = draw.Winners.Rank5EuroMillionsPrize,
                Rank6EuroMillionsWinnersFrance = draw.Winners.Rank6EuroMillionsWinnersFrance,
                Rank6EuroMillionsWinnersEurope = draw.Winners.Rank6EuroMillionsWinnersEurope,
                Rank6EuroMillionsPrize = draw.Winners.Rank6EuroMillionsPrize,
                Rank7EuroMillionsWinnersFrance = draw.Winners.Rank7EuroMillionsWinnersFrance,
                Rank7EuroMillionsWinnersEurope = draw.Winners.Rank7EuroMillionsWinnersEurope,
                Rank7EuroMillionsPrize = draw.Winners.Rank7EuroMillionsPrize,
                Rank8EuroMillionsWinnersFrance = draw.Winners.Rank8EuroMillionsWinnersFrance,
                Rank8EuroMillionsWinnersEurope = draw.Winners.Rank8EuroMillionsWinnersEurope,
                Rank8EuroMillionsPrize = draw.Winners.Rank8EuroMillionsPrize,
                Rank9EuroMillionsWinnersFrance = draw.Winners.Rank9EuroMillionsWinnersFrance,
                Rank9EuroMillionsWinnersEurope = draw.Winners.Rank9EuroMillionsWinnersEurope,
                Rank9EuroMillionsPrize = draw.Winners.Rank9EuroMillionsPrize,
                Rank10EuroMillionsWinnersFrance = draw.Winners.Rank10EuroMillionsWinnersFrance,
                Rank10EuroMillionsWinnersEurope = draw.Winners.Rank10EuroMillionsWinnersEurope,
                Rank10EuroMillionsPrize = draw.Winners.Rank10EuroMillionsPrize,
                Rank11EuroMillionsWinnersFrance = draw.Winners.Rank11EuroMillionsWinnersFrance,
                Rank11EuroMillionsWinnersEurope = draw.Winners.Rank11EuroMillionsWinnersEurope,
                Rank11EuroMillionsPrize = draw.Winners.Rank11EuroMillionsPrize,
                Rank12EuroMillionsWinnersFrance = draw.Winners.Rank12EuroMillionsWinnersFrance,
                Rank12EuroMillionsWinnersEurope = draw.Winners.Rank12EuroMillionsWinnersEurope,
                Rank12EuroMillionsPrize = draw.Winners.Rank12EuroMillionsPrize,
                Rank13EuroMillionsWinnersFrance = draw.Winners.Rank13EuroMillionsWinnersFrance,
                Rank13EuroMillionsWinnersEurope = draw.Winners.Rank13EuroMillionsWinnersEurope,
                Rank13EuroMillionsPrize = draw.Winners.Rank13EuroMillionsPrize,
                Rank1EtoilePlusWinners = draw.Winners.Rank1EtoilePlusWinners,
                Rank1EtoilePlusPrize = draw.Winners.Rank1EtoilePlusPrize,
                Rank2EtoilePlusWinners = draw.Winners.Rank2EtoilePlusWinners,
                Rank2EtoilePlusPrize = draw.Winners.Rank2EtoilePlusPrize,
                Rank3EtoilePlusWinners = draw.Winners.Rank3EtoilePlusWinners,
                Rank3EtoilePlusPrize = draw.Winners.Rank3EtoilePlusPrize,
                Rank4EtoilePlusWinners = draw.Winners.Rank4EtoilePlusWinners,
                Rank4EtoilePlusPrize = draw.Winners.Rank4EtoilePlusPrize,
                Rank5EtoilePlusWinners = draw.Winners.Rank5EtoilePlusWinners,
                Rank5EtoilePlusPrize = draw.Winners.Rank5EtoilePlusPrize,
                Rank6EtoilePlusWinners = draw.Winners.Rank6EtoilePlusWinners,
                Rank6EtoilePlusPrize = draw.Winners.Rank6EtoilePlusPrize,
                Rank7EtoilePlusWinners = draw.Winners.Rank7EtoilePlusWinners,
                Rank7EtoilePlusPrize = draw.Winners.Rank7EtoilePlusPrize,
                Rank8EtoilePlusWinners = draw.Winners.Rank8EtoilePlusWinners,
                Rank8EtoilePlusPrize = draw.Winners.Rank8EtoilePlusPrize,
                Rank9EtoilePlusWinners = draw.Winners.Rank9EtoilePlusWinners,
                Rank9EtoilePlusPrize = draw.Winners.Rank9EtoilePlusPrize,
                Rank10EtoilePlusWinners = draw.Winners.Rank10EtoilePlusWinners,
                Rank10EtoilePlusPrize = draw.Winners.Rank10EtoilePlusPrize
            },
            Reason = reason
        };
}

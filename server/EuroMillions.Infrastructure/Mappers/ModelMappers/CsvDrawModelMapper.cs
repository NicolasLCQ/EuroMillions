using EuroMillions.Application.Models;
using EuroMillions.Infrastructure.Models.csv;

namespace EuroMillions.Infrastructure.Mappers.ModelMappers;

public static class CsvDrawModelMapper
{
    public static Draw ToDrawModel(this CsvDrawModel csvDrawModel) => new Draw
    {
        Ball1 = csvDrawModel.Ball1,
        Ball2 = csvDrawModel.Ball2,
        Ball3 = csvDrawModel.Ball3,
        Ball4 = csvDrawModel.Ball4,
        Ball5 = csvDrawModel.Ball5,
        Star1 = csvDrawModel.Star1,
        Star2 = csvDrawModel.Star2,
        WinningBallsInAscendingOrder = csvDrawModel.WinningBallsInAscendingOrder,
        WinningStarsInAscendingOrder = csvDrawModel.WinningStarsInAscendingOrder,
        DrawInformation = new DrawInformation
        {
            YearDrawNumber = csvDrawModel.YearDrawNumber,
            DrawDate = csvDrawModel.DrawDate,
            DrawDay = csvDrawModel.DrawDay,
            ForclusionDate = csvDrawModel.ForclusionDate,
            DrawNumberInCycle = csvDrawModel.DrawNumberInCycle,
        },
        AdditionalGame = new DrawAdditionalGame
        {
            JokerPlusNumber = csvDrawModel.JokerPlusNumber,
            MyMillionNumber = csvDrawModel.MyMillionNumber,
            ExceptionalEuroMillionsDrawNumber = csvDrawModel.ExceptionalEuroMillionsDrawNumber
        },
        Winners = new DrawWinners
        {
            Currency = csvDrawModel.Currency,
            Rank1EuroMillionsWinnersFrance = csvDrawModel.Rank1EuroMillionsWinnersFrance,
            Rank1EuroMillionsWinnersEurope = csvDrawModel.Rank1EuroMillionsWinnersEurope,
            Rank1EuroMillionsPrize = csvDrawModel.Rank1EuroMillionsPrize,
            Rank2EuroMillionsWinnersFrance = csvDrawModel.Rank2EuroMillionsWinnersFrance,
            Rank2EuroMillionsWinnersEurope = csvDrawModel.Rank2EuroMillionsWinnersEurope,
            Rank2EuroMillionsPrize = csvDrawModel.Rank2EuroMillionsPrize,
            Rank3EuroMillionsWinnersFrance = csvDrawModel.Rank3EuroMillionsWinnersFrance,
            Rank3EuroMillionsWinnersEurope = csvDrawModel.Rank3EuroMillionsWinnersEurope,
            Rank3EuroMillionsPrize = csvDrawModel.Rank3EuroMillionsPrize,
            Rank4EuroMillionsWinnersFrance = csvDrawModel.Rank4EuroMillionsWinnersFrance,
            Rank4EuroMillionsWinnersEurope = csvDrawModel.Rank4EuroMillionsWinnersEurope,
            Rank4EuroMillionsPrize = csvDrawModel.Rank4EuroMillionsPrize,
            Rank5EuroMillionsWinnersFrance = csvDrawModel.Rank5EuroMillionsWinnersFrance,
            Rank5EuroMillionsWinnersEurope = csvDrawModel.Rank5EuroMillionsWinnersEurope,
            Rank5EuroMillionsPrize = csvDrawModel.Rank5EuroMillionsPrize,
            Rank6EuroMillionsWinnersFrance = csvDrawModel.Rank6EuroMillionsWinnersFrance,
            Rank6EuroMillionsWinnersEurope = csvDrawModel.Rank6EuroMillionsWinnersEurope,
            Rank6EuroMillionsPrize = csvDrawModel.Rank6EuroMillionsPrize,
            Rank7EuroMillionsWinnersFrance = csvDrawModel.Rank7EuroMillionsWinnersFrance,
            Rank7EuroMillionsWinnersEurope = csvDrawModel.Rank7EuroMillionsWinnersEurope,
            Rank7EuroMillionsPrize = csvDrawModel.Rank7EuroMillionsPrize,
            Rank8EuroMillionsWinnersFrance = csvDrawModel.Rank8EuroMillionsWinnersFrance,
            Rank8EuroMillionsWinnersEurope = csvDrawModel.Rank8EuroMillionsWinnersEurope,
            Rank8EuroMillionsPrize = csvDrawModel.Rank8EuroMillionsPrize,
            Rank9EuroMillionsWinnersFrance = csvDrawModel.Rank9EuroMillionsWinnersFrance,
            Rank9EuroMillionsWinnersEurope = csvDrawModel.Rank9EuroMillionsWinnersEurope,
            Rank9EuroMillionsPrize = csvDrawModel.Rank9EuroMillionsPrize,
            Rank10EuroMillionsWinnersFrance = csvDrawModel.Rank10EuroMillionsWinnersFrance,
            Rank10EuroMillionsWinnersEurope = csvDrawModel.Rank10EuroMillionsWinnersEurope,
            Rank10EuroMillionsPrize = csvDrawModel.Rank10EuroMillionsPrize,
            Rank11EuroMillionsWinnersFrance = csvDrawModel.Rank11EuroMillionsWinnersFrance,
            Rank11EuroMillionsWinnersEurope = csvDrawModel.Rank11EuroMillionsWinnersEurope,
            Rank11EuroMillionsPrize = csvDrawModel.Rank11EuroMillionsPrize,
            Rank12EuroMillionsWinnersFrance = csvDrawModel.Rank12EuroMillionsWinnersFrance,
            Rank12EuroMillionsWinnersEurope = csvDrawModel.Rank12EuroMillionsWinnersEurope,
            Rank12EuroMillionsPrize = csvDrawModel.Rank12EuroMillionsPrize,
            Rank13EuroMillionsWinnersFrance = csvDrawModel.Rank13EuroMillionsWinnersFrance,
            Rank13EuroMillionsWinnersEurope = csvDrawModel.Rank13EuroMillionsWinnersEurope,
            Rank13EuroMillionsPrize = csvDrawModel.Rank13EuroMillionsPrize,
            Rank1EtoilePlusWinners = csvDrawModel.Rank1EtoilePlusWinners,
            Rank1EtoilePlusPrize = csvDrawModel.Rank1EtoilePlusPrize,
            Rank2EtoilePlusWinners = csvDrawModel.Rank2EtoilePlusWinners,
            Rank2EtoilePlusPrize = csvDrawModel.Rank2EtoilePlusPrize,
            Rank3EtoilePlusWinners = csvDrawModel.Rank3EtoilePlusWinners,
            Rank3EtoilePlusPrize = csvDrawModel.Rank3EtoilePlusPrize,
            Rank4EtoilePlusWinners = csvDrawModel.Rank4EtoilePlusWinners,
            Rank4EtoilePlusPrize = csvDrawModel.Rank4EtoilePlusPrize,
            Rank5EtoilePlusWinners = csvDrawModel.Rank5EtoilePlusWinners,
            Rank5EtoilePlusPrize = csvDrawModel.Rank5EtoilePlusPrize,
            Rank6EtoilePlusWinners = csvDrawModel.Rank6EtoilePlusWinners,
            Rank6EtoilePlusPrize = csvDrawModel.Rank6EtoilePlusPrize,
            Rank7EtoilePlusWinners = csvDrawModel.Rank7EtoilePlusWinners,
            Rank7EtoilePlusPrize = csvDrawModel.Rank7EtoilePlusPrize,
            Rank8EtoilePlusWinners = csvDrawModel.Rank8EtoilePlusWinners,
            Rank8EtoilePlusPrize = csvDrawModel.Rank8EtoilePlusPrize,
            Rank9EtoilePlusWinners = csvDrawModel.Rank9EtoilePlusWinners,
            Rank9EtoilePlusPrize = csvDrawModel.Rank9EtoilePlusPrize,
            Rank10EtoilePlusWinners = csvDrawModel.Rank10EtoilePlusWinners,
            Rank10EtoilePlusPrize = csvDrawModel.Rank10EtoilePlusPrize
        }
    };
}

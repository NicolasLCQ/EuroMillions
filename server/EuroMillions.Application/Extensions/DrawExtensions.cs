using EuroMillions.Application.Models;
using EuroMillions.Application.Models.Upload;

namespace EuroMillions.Application.Extensions;

public static class DrawExtensions
{
    //todo :: sortir le mapping et vérifier que validate est util.
    //todo :: (puisque un draw est un type en lui meme, il serait normal de faire soter les erreurs dedans)
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
            DrawDay = draw.DrawDay,
            ForclusionDate = draw.ForclusionDate,
            DrawNumberInCycle = draw.DrawNumberInCycle,
            WinningBallsInAscendingOrder = draw.WinningBallsInAscendingOrder,
            WinningStarsInAscendingOrder = draw.WinningStarsInAscendingOrder,
            JokerPlusNumber = draw.JokerPlusNumber,
            MyMillionNumber = draw.MyMillionNumber,
            ExceptionalEuroMillionsDrawNumber = draw.ExceptionalEuroMillionsDrawNumber,
            Currency = draw.Currency,
            Rank1EuroMillionsWinnersFrance = draw.Rank1EuroMillionsWinnersFrance,
            Rank1EuroMillionsWinnersEurope = draw.Rank1EuroMillionsWinnersEurope,
            Rank1EuroMillionsPrize = draw.Rank1EuroMillionsPrize,
            Rank2EuroMillionsWinnersFrance = draw.Rank2EuroMillionsWinnersFrance,
            Rank2EuroMillionsWinnersEurope = draw.Rank2EuroMillionsWinnersEurope,
            Rank2EuroMillionsPrize = draw.Rank2EuroMillionsPrize,
            Rank3EuroMillionsWinnersFrance = draw.Rank3EuroMillionsWinnersFrance,
            Rank3EuroMillionsWinnersEurope = draw.Rank3EuroMillionsWinnersEurope,
            Rank3EuroMillionsPrize = draw.Rank3EuroMillionsPrize,
            Rank4EuroMillionsWinnersFrance = draw.Rank4EuroMillionsWinnersFrance,
            Rank4EuroMillionsWinnersEurope = draw.Rank4EuroMillionsWinnersEurope,
            Rank4EuroMillionsPrize = draw.Rank4EuroMillionsPrize,
            Rank5EuroMillionsWinnersFrance = draw.Rank5EuroMillionsWinnersFrance,
            Rank5EuroMillionsWinnersEurope = draw.Rank5EuroMillionsWinnersEurope,
            Rank5EuroMillionsPrize = draw.Rank5EuroMillionsPrize,
            Rank6EuroMillionsWinnersFrance = draw.Rank6EuroMillionsWinnersFrance,
            Rank6EuroMillionsWinnersEurope = draw.Rank6EuroMillionsWinnersEurope,
            Rank6EuroMillionsPrize = draw.Rank6EuroMillionsPrize,
            Rank7EuroMillionsWinnersFrance = draw.Rank7EuroMillionsWinnersFrance,
            Rank7EuroMillionsWinnersEurope = draw.Rank7EuroMillionsWinnersEurope,
            Rank7EuroMillionsPrize = draw.Rank7EuroMillionsPrize,
            Rank8EuroMillionsWinnersFrance = draw.Rank8EuroMillionsWinnersFrance,
            Rank8EuroMillionsWinnersEurope = draw.Rank8EuroMillionsWinnersEurope,
            Rank8EuroMillionsPrize = draw.Rank8EuroMillionsPrize,
            Rank9EuroMillionsWinnersFrance = draw.Rank9EuroMillionsWinnersFrance,
            Rank9EuroMillionsWinnersEurope = draw.Rank9EuroMillionsWinnersEurope,
            Rank9EuroMillionsPrize = draw.Rank9EuroMillionsPrize,
            Rank10EuroMillionsWinnersFrance = draw.Rank10EuroMillionsWinnersFrance,
            Rank10EuroMillionsWinnersEurope = draw.Rank10EuroMillionsWinnersEurope,
            Rank10EuroMillionsPrize = draw.Rank10EuroMillionsPrize,
            Rank11EuroMillionsWinnersFrance = draw.Rank11EuroMillionsWinnersFrance,
            Rank11EuroMillionsWinnersEurope = draw.Rank11EuroMillionsWinnersEurope,
            Rank11EuroMillionsPrize = draw.Rank11EuroMillionsPrize,
            Rank12EuroMillionsWinnersFrance = draw.Rank12EuroMillionsWinnersFrance,
            Rank12EuroMillionsWinnersEurope = draw.Rank12EuroMillionsWinnersEurope,
            Rank12EuroMillionsPrize = draw.Rank12EuroMillionsPrize,
            Rank13EuroMillionsWinnersFrance = draw.Rank13EuroMillionsWinnersFrance,
            Rank13EuroMillionsWinnersEurope = draw.Rank13EuroMillionsWinnersEurope,
            Rank13EuroMillionsPrize = draw.Rank13EuroMillionsPrize,
            Rank1EtoilePlusWinners = draw.Rank1EtoilePlusWinners,
            Rank1EtoilePlusPrize = draw.Rank1EtoilePlusPrize,
            Rank2EtoilePlusWinners = draw.Rank2EtoilePlusWinners,
            Rank2EtoilePlusPrize = draw.Rank2EtoilePlusPrize,
            Rank3EtoilePlusWinners = draw.Rank3EtoilePlusWinners,
            Rank3EtoilePlusPrize = draw.Rank3EtoilePlusPrize,
            Rank4EtoilePlusWinners = draw.Rank4EtoilePlusWinners,
            Rank4EtoilePlusPrize = draw.Rank4EtoilePlusPrize,
            Rank5EtoilePlusWinners = draw.Rank5EtoilePlusWinners,
            Rank5EtoilePlusPrize = draw.Rank5EtoilePlusPrize,
            Rank6EtoilePlusWinners = draw.Rank6EtoilePlusWinners,
            Rank6EtoilePlusPrize = draw.Rank6EtoilePlusPrize,
            Rank7EtoilePlusWinners = draw.Rank7EtoilePlusWinners,
            Rank7EtoilePlusPrize = draw.Rank7EtoilePlusPrize,
            Rank8EtoilePlusWinners = draw.Rank8EtoilePlusWinners,
            Rank8EtoilePlusPrize = draw.Rank8EtoilePlusPrize,
            Rank9EtoilePlusWinners = draw.Rank9EtoilePlusWinners,
            Rank9EtoilePlusPrize = draw.Rank9EtoilePlusPrize,
            Rank10EtoilePlusWinners = draw.Rank10EtoilePlusWinners,
            Rank10EtoilePlusPrize = draw.Rank10EtoilePlusPrize,
            Reason = reason
        };
}

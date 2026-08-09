using EuroMillions.API.ViewModels;
using EuroMillions.Application.Models;
using EuroMillions.Application.Models.Upload;

namespace EuroMillions.API.Mappers;

public static class DrawMapper
{
    public static DrawResponseViewModel ToDrawResponseViewModel(this DrawSummaryModel summary) =>
        new DrawResponseViewModel
        {
            DrawNumber = summary.DrawNumber,
            DrawDate = summary.DrawDate,
            Ball1 = summary.Ball1,
            Ball2 = summary.Ball2,
            Ball3 = summary.Ball3,
            Ball4 = summary.Ball4,
            Ball5 = summary.Ball5,
            Star1 = summary.Star1,
            Star2 = summary.Star2,
            JokerPlusNumber = summary.JokerPlusNumber,
            MyMillionNumber = summary.MyMillionNumber,
            ExceptionalEuroMillionsDrawNumber = summary.ExceptionalEuroMillionsDrawNumber,
            EuroMillionsPrizeRanks = summary.Winners?.ToEuroMillionsPrizeRanks() ?? []
        };

    public static DrawResponseViewModel ToDrawResponseViewModel(this Draw draw) =>
        new DrawResponseViewModel
        {
            DrawNumber = draw.DrawInformation.YearDrawNumber,
            DrawDate = draw.DrawInformation.DrawDate,
            Ball1 = draw.Ball1,
            Ball2 = draw.Ball2,
            Ball3 = draw.Ball3,
            Ball4 = draw.Ball4,
            Ball5 = draw.Ball5,
            Star1 = draw.Star1,
            Star2 = draw.Star2,
            JokerPlusNumber = draw.AdditionalGame?.JokerPlusNumber,
            MyMillionNumber = draw.AdditionalGame?.MyMillionNumber,
            ExceptionalEuroMillionsDrawNumber = draw.AdditionalGame?.ExceptionalEuroMillionsDrawNumber,
            EuroMillionsPrizeRanks = draw.Winners.ToEuroMillionsPrizeRanks()
        };

    public static RejectedDrawResponseViewModel ToRejectedDrawResponseViewModel(this RejectedDraw draw) =>
        new RejectedDrawResponseViewModel
        {
            DrawNumber = draw.DrawInformation.YearDrawNumber,
            DrawDate = draw.DrawInformation.DrawDate,
            Ball1 = draw.Ball1,
            Ball2 = draw.Ball2,
            Ball3 = draw.Ball3,
            Ball4 = draw.Ball4,
            Ball5 = draw.Ball5,
            Star1 = draw.Star1,
            Star2 = draw.Star2,
            Reason = draw.Reason,
            JokerPlusNumber = draw.AdditionalGame?.JokerPlusNumber,
            MyMillionNumber = draw.AdditionalGame?.MyMillionNumber,
            ExceptionalEuroMillionsDrawNumber = draw.AdditionalGame?.ExceptionalEuroMillionsDrawNumber,
            EuroMillionsPrizeRanks = draw.Winners.ToEuroMillionsPrizeRanks()
        };

    private static List<DrawPrizeRankResponseViewModel> ToEuroMillionsPrizeRanks(this DrawWinners winners) =>
    [
        ToPrizeRank(
            1,
            winners.Rank1EuroMillionsWinnersFrance,
            winners.Rank1EuroMillionsWinnersEurope,
            winners.Rank1EuroMillionsPrize
        ),
        ToPrizeRank(
            2,
            winners.Rank2EuroMillionsWinnersFrance,
            winners.Rank2EuroMillionsWinnersEurope,
            winners.Rank2EuroMillionsPrize
        ),
        ToPrizeRank(
            3,
            winners.Rank3EuroMillionsWinnersFrance,
            winners.Rank3EuroMillionsWinnersEurope,
            winners.Rank3EuroMillionsPrize
        ),
        ToPrizeRank(
            4,
            winners.Rank4EuroMillionsWinnersFrance,
            winners.Rank4EuroMillionsWinnersEurope,
            winners.Rank4EuroMillionsPrize
        ),
        ToPrizeRank(
            5,
            winners.Rank5EuroMillionsWinnersFrance,
            winners.Rank5EuroMillionsWinnersEurope,
            winners.Rank5EuroMillionsPrize
        ),
        ToPrizeRank(
            6,
            winners.Rank6EuroMillionsWinnersFrance,
            winners.Rank6EuroMillionsWinnersEurope,
            winners.Rank6EuroMillionsPrize
        ),
        ToPrizeRank(
            7,
            winners.Rank7EuroMillionsWinnersFrance,
            winners.Rank7EuroMillionsWinnersEurope,
            winners.Rank7EuroMillionsPrize
        ),
        ToPrizeRank(
            8,
            winners.Rank8EuroMillionsWinnersFrance,
            winners.Rank8EuroMillionsWinnersEurope,
            winners.Rank8EuroMillionsPrize
        ),
        ToPrizeRank(
            9,
            winners.Rank9EuroMillionsWinnersFrance,
            winners.Rank9EuroMillionsWinnersEurope,
            winners.Rank9EuroMillionsPrize
        ),
        ToPrizeRank(
            10,
            winners.Rank10EuroMillionsWinnersFrance,
            winners.Rank10EuroMillionsWinnersEurope,
            winners.Rank10EuroMillionsPrize
        ),
        ToPrizeRank(
            11,
            winners.Rank11EuroMillionsWinnersFrance,
            winners.Rank11EuroMillionsWinnersEurope,
            winners.Rank11EuroMillionsPrize
        ),
        ToPrizeRank(
            12,
            winners.Rank12EuroMillionsWinnersFrance,
            winners.Rank12EuroMillionsWinnersEurope,
            winners.Rank12EuroMillionsPrize
        ),
        ToPrizeRank(
            13,
            winners.Rank13EuroMillionsWinnersFrance,
            winners.Rank13EuroMillionsWinnersEurope,
            winners.Rank13EuroMillionsPrize
        )
    ];

    private static DrawPrizeRankResponseViewModel ToPrizeRank(int rank, int? winnersFrance, int? winnersEurope, decimal? prize) =>
        new DrawPrizeRankResponseViewModel
        {
            Rank = rank,
            WinnersFrance = winnersFrance.GetValueOrDefault(),
            WinnersEurope = winnersEurope.GetValueOrDefault(),
            Prize = prize.GetValueOrDefault()
        };
}

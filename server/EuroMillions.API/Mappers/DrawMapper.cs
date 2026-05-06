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
            Star2 = summary.Star2
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
            Star2 = draw.Star2
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
            Reason = draw.Reason
        };
}

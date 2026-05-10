using EuroMillions.Application.Consts;
using EuroMillions.Application.Models;

namespace EuroMillions.Application.UseCases;

public partial class DrawUseCases
{
    public async Task<bool> AreUpToDateAsync()
    {
        DrawSummaryModel? latestDrawUploaded = await drawRepository.GetLastDrawAsync();

        if (latestDrawUploaded == null)
        {
            return false;
        }

        DateTime now = DateTime.Now;

        DateTime lastResultPublicationDateTime = Enumerable.Range(0, 7)
            .Select(i => DateTime.Today.AddDays(-i))
            .Where(day => DrawConsts.DrawDays.Contains(day.DayOfWeek))
            .First(day => now >= day.Add(DrawConsts.DrawResultAvailabilityTime.ToTimeSpan()));

        return latestDrawUploaded.DrawDate.Date == lastResultPublicationDateTime.Date;
    }
}

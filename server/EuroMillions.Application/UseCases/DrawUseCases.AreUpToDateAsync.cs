using EuroMillions.Application.Consts;
using EuroMillions.Application.Extensions;
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

        List<DayOfWeek> drawPublicationDays = DrawConsts.DrawDays
            .Select(day => day + 1)
            .ToList();

        DateTime lastDrawPublicationDate = Enumerable.Range(0, 7)
            .Select(i => DateTime.Today.AddDays(-i))
            .First(day => drawPublicationDays.Contains(day.DayOfWeek));

        return latestDrawUploaded.DrawDate.AddDays(1) == lastDrawPublicationDate;
    }
}

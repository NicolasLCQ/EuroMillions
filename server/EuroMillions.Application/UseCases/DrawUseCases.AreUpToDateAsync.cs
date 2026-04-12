using EuroMillions.Application.Models;

namespace EuroMillions.Application.UseCases;

public partial class DrawUseCases
{
    public async Task<bool> AreUpToDateAsync()
    {
        Draw? latestDrawUploaded = await drawRepository.GetLastDrawAsync();

        if (latestDrawUploaded == null)
        {
            return false;
        }

        List<DayOfWeek> drawDays = [DayOfWeek.Tuesday, DayOfWeek.Friday];

        List<DayOfWeek> drawPublicationDays = drawDays
            .Select(day => day + 1)
            .ToList();

        DateTime lastDrawPublicationDate = Enumerable.Range(0, 7)
            .Select(i => DateTime.Today.AddDays(-i))
            .First(day => drawPublicationDays.Contains(day.DayOfWeek));

        DateTime latestDrawUploadedPublicationDate = latestDrawUploaded.DrawDate.AddDays(1);

        return latestDrawUploadedPublicationDate == lastDrawPublicationDate;
    }
}

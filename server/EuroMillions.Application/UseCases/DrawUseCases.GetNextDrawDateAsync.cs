using EuroMillions.Application.Consts;

namespace EuroMillions.Application.UseCases;

public partial class DrawUseCases
{
    public Task<DateTime> GetNextDrawDateAsync()
    {
        DateTime now = DateTime.Now;

        DateTime nextDrawDate = Enumerable.Range(0, 7)
            .Select(i => DateTime.Today.AddDays(i))
            .Where(day => DrawConsts.DrawDays.Contains(day.DayOfWeek))
            .First(day => now < day.Add(DrawConsts.DrawResultAvailabilityTime.ToTimeSpan()));

        return Task.FromResult(nextDrawDate);
    }
}

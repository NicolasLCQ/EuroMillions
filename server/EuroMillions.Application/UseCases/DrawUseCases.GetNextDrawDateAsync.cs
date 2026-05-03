using EuroMillions.Application.Consts;

namespace EuroMillions.Application.UseCases;

public partial class DrawUseCases
{
    public Task<DateTime> GetNextDrawDateAsync()
    {
        DateTime nextDrawDate = Enumerable.Range(0, 7)
            .Select(i => DateTime.Today.AddDays(i))
            .First(day => DrawConsts.DrawDays.Contains(day.DayOfWeek));

        return Task.FromResult(nextDrawDate);
    }
}

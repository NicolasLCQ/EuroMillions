using EuroMillions.Application.Consts;
using EuroMillions.Application.Models;

namespace EuroMillions.Application.UseCases;

public partial class DrawUseCases
{
    public Task<DrawDate> GetNextDrawDateAsync()
    {
        DrawDate nextDrawDate = Enumerable.Range(0, 7)
            .Select(i => DateTime.Today.AddDays(i))
            .First(day => DrawConsts.DrawDays.Contains(day.DayOfWeek));

        return Task.FromResult(nextDrawDate);
    }
}

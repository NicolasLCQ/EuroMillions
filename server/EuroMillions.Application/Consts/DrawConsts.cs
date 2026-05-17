namespace EuroMillions.Application.Consts;

public static class DrawConsts
{
    public static readonly DayOfWeek[] DrawDays = [DayOfWeek.Tuesday, DayOfWeek.Friday];
    public static readonly TimeOnly DrawResultAvailabilityTime = new TimeOnly(21, 45);
}

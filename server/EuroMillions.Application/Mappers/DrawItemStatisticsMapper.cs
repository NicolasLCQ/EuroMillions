using EuroMillions.Application.Models;

namespace EuroMillions.Application.Mappers;

public static class DrawItemStatisticsMapper
{
    public static DrawItemStatisticsModel<TDrawItem> ToDrawItemStatisticsModel<TDrawItem>(
        this KeyValuePair<TDrawItem, int> entry)
        where TDrawItem : notnull =>
        new DrawItemStatisticsModel<TDrawItem>
        {
            DrawItem = entry.Key,
            NbTimesDraw = entry.Value
        };
}

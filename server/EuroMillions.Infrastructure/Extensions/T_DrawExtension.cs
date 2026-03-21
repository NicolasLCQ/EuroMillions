using EuroMillions.Infrastructure.Entities;

namespace EuroMillions.Infrastructure.Extensions;

public static class T_DrawExtension
{
    public static DateTime GetPublicationDate(this T_DRAW draw) => draw.DRAW_DATE.AddDays(1);
}

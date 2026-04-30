using EuroMillions.Infrastructure.Entities;

namespace EuroMillions.Infrastructure.Extensions;

public static class T_DrawExtension
{
    public static DateTime GetPublicationDate(this T_DRAW draw) => draw.T_DRAW_INFORMATION!.DRAW_DATE.AddDays(1);
}

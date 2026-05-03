namespace EuroMillions.Infrastructure.Entities;

public partial class T_DRAW_INFORMATION
{
    public int DRAW_ID { get; set; }

    public int YEAR_DRAW_NUMBER { get; set; }

    public DateTime DRAW_DATE { get; set; }

    public string? DRAW_DAY { get; set; }

    public DateTime? FORCLUSION_DATE { get; set; }

    public int? DRAW_NUMBER_IN_CYCLE { get; set; }

    public virtual T_DRAW DRAW { get; set; } = null!;
}

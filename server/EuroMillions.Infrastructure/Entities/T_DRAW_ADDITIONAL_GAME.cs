namespace EuroMillions.Infrastructure.Entities;

public partial class T_DRAW_ADDITIONAL_GAME
{
    public int DRAW_ID { get; set; }

    public string? JOKER_PLUS_NUMBER { get; set; }

    public string? MY_MILLION_NUMBER { get; set; }

    public string? EXCEPTIONAL_EURO_MILLIONS_DRAW_NUMBER { get; set; }

    public virtual T_DRAW DRAW { get; set; } = null!;
}

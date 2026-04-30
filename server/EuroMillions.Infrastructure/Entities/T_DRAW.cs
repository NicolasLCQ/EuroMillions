namespace EuroMillions.Infrastructure.Entities;

public partial class T_DRAW
{
    public int ID { get; set; }

    public int BALL_ONE { get; set; }

    public int BALL_TWO { get; set; }

    public int BALL_THREE { get; set; }

    public int BALL_FOUR { get; set; }

    public int BALL_FIVE { get; set; }

    public int STAR_ONE { get; set; }

    public int STAR_TWO { get; set; }

    public string? WINNING_BALLS_IN_ASCENDING_ORDER { get; set; }

    public string? WINNING_STARS_IN_ASCENDING_ORDER { get; set; }

    public virtual T_DRAW_ADDITIONAL_GAME? T_DRAW_ADDITIONAL_GAME { get; set; }

    public virtual T_DRAW_INFORMATION? T_DRAW_INFORMATION { get; set; }

    public virtual T_DRAW_WINNER? T_DRAW_WINNER { get; set; }
}

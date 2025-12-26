using System;
using System.Collections.Generic;

namespace EuroMillions.Infrastructure.Entities;

public partial class T_DRAW
{
    public int ID { get; set; }

    public int YEAR_DRAW_NUMBER { get; set; }

    public DateTime DRAW_DATE { get; set; }

    public int BALL_ONE { get; set; }

    public int BALL_TWO { get; set; }

    public int BALL_THREE { get; set; }

    public int BALL_FOUR { get; set; }

    public int BALL_FIVE { get; set; }

    public int STAR_ONE { get; set; }

    public int STAR_TWO { get; set; }
}

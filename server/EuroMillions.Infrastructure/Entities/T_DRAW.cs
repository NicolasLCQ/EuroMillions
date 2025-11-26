using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EuroMillions.Infrastructure.Entities;

[Table("T_DRAW")]
public class T_DRAW
{
    [Key]
    public int ID { get; set; }

    public int YEAR_DRAW_NUMBER { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime DRAW_DATE { get; set; }

    public int BALL_ONE { get; set; }

    public int BALL_TWO { get; set; }

    public int BALL_THREE { get; set; }

    public int BALL_FOUR { get; set; }

    public int BALL_FIVE { get; set; }

    public int STAR_ONE { get; set; }

    public int STAR_TWO { get; set; }
}

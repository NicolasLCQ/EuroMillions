namespace EuroMillions.Infrastructure.Entities;

public partial class T_DRAW_WINNER
{
    public int DRAW_ID { get; set; }

    public string? CURRENCY { get; set; }

    public int? RANK_1_EURO_MILLIONS_WINNERS_FRANCE { get; set; }

    public int? RANK_1_EURO_MILLIONS_WINNERS_EUROPE { get; set; }

    public double? RANK_1_EURO_MILLIONS_PRIZE { get; set; }

    public int? RANK_2_EURO_MILLIONS_WINNERS_FRANCE { get; set; }

    public int? RANK_2_EURO_MILLIONS_WINNERS_EUROPE { get; set; }

    public double? RANK_2_EURO_MILLIONS_PRIZE { get; set; }

    public int? RANK_3_EURO_MILLIONS_WINNERS_FRANCE { get; set; }

    public int? RANK_3_EURO_MILLIONS_WINNERS_EUROPE { get; set; }

    public double? RANK_3_EURO_MILLIONS_PRIZE { get; set; }

    public int? RANK_4_EURO_MILLIONS_WINNERS_FRANCE { get; set; }

    public int? RANK_4_EURO_MILLIONS_WINNERS_EUROPE { get; set; }

    public double? RANK_4_EURO_MILLIONS_PRIZE { get; set; }

    public int? RANK_5_EURO_MILLIONS_WINNERS_FRANCE { get; set; }

    public int? RANK_5_EURO_MILLIONS_WINNERS_EUROPE { get; set; }

    public double? RANK_5_EURO_MILLIONS_PRIZE { get; set; }

    public int? RANK_6_EURO_MILLIONS_WINNERS_FRANCE { get; set; }

    public int? RANK_6_EURO_MILLIONS_WINNERS_EUROPE { get; set; }

    public double? RANK_6_EURO_MILLIONS_PRIZE { get; set; }

    public int? RANK_7_EURO_MILLIONS_WINNERS_FRANCE { get; set; }

    public int? RANK_7_EURO_MILLIONS_WINNERS_EUROPE { get; set; }

    public double? RANK_7_EURO_MILLIONS_PRIZE { get; set; }

    public int? RANK_8_EURO_MILLIONS_WINNERS_FRANCE { get; set; }

    public int? RANK_8_EURO_MILLIONS_WINNERS_EUROPE { get; set; }

    public double? RANK_8_EURO_MILLIONS_PRIZE { get; set; }

    public int? RANK_9_EURO_MILLIONS_WINNERS_FRANCE { get; set; }

    public int? RANK_9_EURO_MILLIONS_WINNERS_EUROPE { get; set; }

    public double? RANK_9_EURO_MILLIONS_PRIZE { get; set; }

    public int? RANK_10_EURO_MILLIONS_WINNERS_FRANCE { get; set; }

    public int? RANK_10_EURO_MILLIONS_WINNERS_EUROPE { get; set; }

    public double? RANK_10_EURO_MILLIONS_PRIZE { get; set; }

    public int? RANK_11_EURO_MILLIONS_WINNERS_FRANCE { get; set; }

    public int? RANK_11_EURO_MILLIONS_WINNERS_EUROPE { get; set; }

    public double? RANK_11_EURO_MILLIONS_PRIZE { get; set; }

    public int? RANK_12_EURO_MILLIONS_WINNERS_FRANCE { get; set; }

    public int? RANK_12_EURO_MILLIONS_WINNERS_EUROPE { get; set; }

    public double? RANK_12_EURO_MILLIONS_PRIZE { get; set; }

    public int? RANK_13_EURO_MILLIONS_WINNERS_FRANCE { get; set; }

    public int? RANK_13_EURO_MILLIONS_WINNERS_EUROPE { get; set; }

    public double? RANK_13_EURO_MILLIONS_PRIZE { get; set; }

    public int? RANK_1_ETOILE_PLUS_WINNERS { get; set; }

    public double? RANK_1_ETOILE_PLUS_PRIZE { get; set; }

    public int? RANK_2_ETOILE_PLUS_WINNERS { get; set; }

    public double? RANK_2_ETOILE_PLUS_PRIZE { get; set; }

    public int? RANK_3_ETOILE_PLUS_WINNERS { get; set; }

    public double? RANK_3_ETOILE_PLUS_PRIZE { get; set; }

    public int? RANK_4_ETOILE_PLUS_WINNERS { get; set; }

    public double? RANK_4_ETOILE_PLUS_PRIZE { get; set; }

    public int? RANK_5_ETOILE_PLUS_WINNERS { get; set; }

    public double? RANK_5_ETOILE_PLUS_PRIZE { get; set; }

    public int? RANK_6_ETOILE_PLUS_WINNERS { get; set; }

    public double? RANK_6_ETOILE_PLUS_PRIZE { get; set; }

    public int? RANK_7_ETOILE_PLUS_WINNERS { get; set; }

    public double? RANK_7_ETOILE_PLUS_PRIZE { get; set; }

    public int? RANK_8_ETOILE_PLUS_WINNERS { get; set; }

    public double? RANK_8_ETOILE_PLUS_PRIZE { get; set; }

    public int? RANK_9_ETOILE_PLUS_WINNERS { get; set; }

    public double? RANK_9_ETOILE_PLUS_PRIZE { get; set; }

    public int? RANK_10_ETOILE_PLUS_WINNERS { get; set; }

    public double? RANK_10_ETOILE_PLUS_PRIZE { get; set; }

    public virtual T_DRAW DRAW { get; set; } = null!;
}

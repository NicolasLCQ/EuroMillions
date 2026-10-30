using CsvHelper;

using EuroMillions.Infrastructure.Models.csv;

namespace EuroMillions.Infrastructure.Mappers.CsvMappers;

[CsvRecordMap(typeof(CsvDrawModel))]
internal partial class CsvDrawMap
{
    [CsvColumn("annee_numero_de_tirage")]
    public int YearDrawNumber { get; set; }

    [CsvColumn("date_de_tirage")]
    [CsvFormat("yyyyMMdd", "dd/MM/yyyy", "dd/MM/yy")]
    public DateTime DrawDate { get; set; }

    [CsvColumn("boule_1")]
    public int Ball1 { get; set; }

    [CsvColumn("boule_2")]
    public int Ball2 { get; set; }

    [CsvColumn("boule_3")]
    public int Ball3 { get; set; }

    [CsvColumn("boule_4")]
    public int Ball4 { get; set; }

    [CsvColumn("boule_5")]
    public int Ball5 { get; set; }

    [CsvColumn("etoile_1")]
    public int Star1 { get; set; }

    [CsvColumn("etoile_2")]
    public int Star2 { get; set; }

    [CsvColumn("jour_de_tirage")]
    public string DrawDay { get; set; } = string.Empty;

    [CsvColumn("date_de_forclusion")]
    [CsvFormat("yyyyMMdd", "dd/MM/yyyy", "dd/MM/yy")]
    public DateTime ForclusionDate { get; set; }

    [CsvColumn(
        "num\u00E9ro_de_tirage_dans_le_cycle",
        "num\uFFFDro_de_tirage_dans_le_cycle",
        "num\u00C3\u00A9ro_de_tirage_dans_le_cycle",
        "numero_de_tirage_dans_le_cycle",
        Optional = true
    )]
    [CsvConverter(typeof(FdjIntConverter))]
    public int DrawNumberInCycle { get; set; }

    [CsvColumn("boules_gagnantes_en_ordre_croissant")]
    public string WinningBallsInAscendingOrder { get; set; } = string.Empty;

    [CsvColumn("etoiles_gagnantes_en_ordre_croissant")]
    public string WinningStarsInAscendingOrder { get; set; } = string.Empty;

    [CsvColumn("numero_jokerplus", Optional = true)]
    public string? JokerPlusNumber { get; set; }

    [CsvColumn("numero_My_Million", Optional = true)]
    public string? MyMillionNumber { get; set; }

    [CsvColumn("numero_Tirage_Exceptionnel_Euro_Million", "numero_Tirage_Exceptionnel_Euro_Millions", Optional = true)]
    public string? ExceptionalEuroMillionsDrawNumber { get; set; }

    [CsvColumn("nombre_de_gagnant_au_rang1_en_france", "nombre_de_gagnant_au_rang1_Euro_Millions_en_france")]
    public int Rank1EuroMillionsWinnersFrance { get; set; }

    [CsvColumn("nombre_de_gagnant_au_rang1_en_europe", "nombre_de_gagnant_au_rang1_Euro_Millions_en_europe")]
    public int Rank1EuroMillionsWinnersEurope { get; set; }

    [CsvColumn("rapport_du_rang1", "rapport_du_rang1_Euro_Millions")]
    [CsvConverter(typeof(FdjDecimalConverter))]
    public decimal Rank1EuroMillionsPrize { get; set; }

    [CsvColumn("nombre_de_gagnant_au_rang2_en_france", "nombre_de_gagnant_au_rang2_Euro_Millions_en_france")]
    public int Rank2EuroMillionsWinnersFrance { get; set; }

    [CsvColumn("nombre_de_gagnant_au_rang2_en_europe", "nombre_de_gagnant_au_rang2_Euro_Millions_en_europe")]
    public int Rank2EuroMillionsWinnersEurope { get; set; }

    [CsvColumn("rapport_du_rang2", "rapport_du_rang2_Euro_Millions")]
    [CsvConverter(typeof(FdjDecimalConverter))]
    public decimal Rank2EuroMillionsPrize { get; set; }

    [CsvColumn("nombre_de_gagnant_au_rang3_en_france", "nombre_de_gagnant_au_rang3_Euro_Millions_en_france")]
    public int Rank3EuroMillionsWinnersFrance { get; set; }

    [CsvColumn("nombre_de_gagnant_au_rang3_en_europe", "nombre_de_gagnant_au_rang3_Euro_Millions_en_europe")]
    public int Rank3EuroMillionsWinnersEurope { get; set; }

    [CsvColumn("rapport_du_rang3", "rapport_du_rang3_Euro_Millions")]
    [CsvConverter(typeof(FdjDecimalConverter))]
    public decimal Rank3EuroMillionsPrize { get; set; }

    [CsvColumn("nombre_de_gagnant_au_rang4_en_france", "nombre_de_gagnant_au_rang4_Euro_Millions_en_france")]
    public int Rank4EuroMillionsWinnersFrance { get; set; }

    [CsvColumn("nombre_de_gagnant_au_rang4_en_europe", "nombre_de_gagnant_au_rang4_Euro_Millions_en_europe")]
    public int Rank4EuroMillionsWinnersEurope { get; set; }

    [CsvColumn("rapport_du_rang4", "rapport_du_rang4_Euro_Millions")]
    [CsvConverter(typeof(FdjDecimalConverter))]
    public decimal Rank4EuroMillionsPrize { get; set; }

    [CsvColumn("nombre_de_gagnant_au_rang5_en_france", "nombre_de_gagnant_au_rang5_Euro_Millions_en_france")]
    public int Rank5EuroMillionsWinnersFrance { get; set; }

    [CsvColumn("nombre_de_gagnant_au_rang5_en_europe", "nombre_de_gagnant_au_rang5_Euro_Millions_en_europe")]
    public int Rank5EuroMillionsWinnersEurope { get; set; }

    [CsvColumn("rapport_du_rang5", "rapport_du_rang5_Euro_Millions")]
    [CsvConverter(typeof(FdjDecimalConverter))]
    public decimal Rank5EuroMillionsPrize { get; set; }

    [CsvColumn("nombre_de_gagnant_au_rang6_en_france", "nombre_de_gagnant_au_rang6_Euro_Millions_en_france")]
    public int Rank6EuroMillionsWinnersFrance { get; set; }

    [CsvColumn("nombre_de_gagnant_au_rang6_en_europe", "nombre_de_gagnant_au_rang6_Euro_Millions_en_europe")]
    public int Rank6EuroMillionsWinnersEurope { get; set; }

    [CsvColumn("rapport_du_rang6", "rapport_du_rang6_Euro_Millions")]
    [CsvConverter(typeof(FdjDecimalConverter))]
    public decimal Rank6EuroMillionsPrize { get; set; }

    [CsvColumn("nombre_de_gagnant_au_rang7_en_france", "nombre_de_gagnant_au_rang7_Euro_Millions_en_france")]
    public int Rank7EuroMillionsWinnersFrance { get; set; }

    [CsvColumn("nombre_de_gagnant_au_rang7_en_europe", "nombre_de_gagnant_au_rang7_Euro_Millions_en_europe")]
    public int Rank7EuroMillionsWinnersEurope { get; set; }

    [CsvColumn("rapport_du_rang7", "rapport_du_rang7_Euro_Millions")]
    [CsvConverter(typeof(FdjDecimalConverter))]
    public decimal Rank7EuroMillionsPrize { get; set; }

    [CsvColumn("nombre_de_gagnant_au_rang8_en_france", "nombre_de_gagnant_au_rang8_Euro_Millions_en_france")]
    public int Rank8EuroMillionsWinnersFrance { get; set; }

    [CsvColumn("nombre_de_gagnant_au_rang8_en_europe", "nombre_de_gagnant_au_rang8_Euro_Millions_en_europe")]
    public int Rank8EuroMillionsWinnersEurope { get; set; }

    [CsvColumn("rapport_du_rang8", "rapport_du_rang8_Euro_Millions")]
    [CsvConverter(typeof(FdjDecimalConverter))]
    public decimal Rank8EuroMillionsPrize { get; set; }

    [CsvColumn("nombre_de_gagnant_au_rang9_en_france", "nombre_de_gagnant_au_rang9_Euro_Millions_en_france")]
    public int Rank9EuroMillionsWinnersFrance { get; set; }

    [CsvColumn("nombre_de_gagnant_au_rang9_en_europe", "nombre_de_gagnant_au_rang9_Euro_Millions_en_europe")]
    public int Rank9EuroMillionsWinnersEurope { get; set; }

    [CsvColumn("rapport_du_rang9", "rapport_du_rang9_Euro_Millions")]
    [CsvConverter(typeof(FdjDecimalConverter))]
    public decimal Rank9EuroMillionsPrize { get; set; }

    [CsvColumn("nombre_de_gagnant_au_rang10_en_france", "nombre_de_gagnant_au_rang10_Euro_Millions_en_france")]
    public int Rank10EuroMillionsWinnersFrance { get; set; }

    [CsvColumn("nombre_de_gagnant_au_rang10_en_europe", "nombre_de_gagnant_au_rang10_Euro_Millions_en_europe")]
    public int Rank10EuroMillionsWinnersEurope { get; set; }

    [CsvColumn("rapport_du_rang10", "rapport_du_rang10_Euro_Millions")]
    [CsvConverter(typeof(FdjDecimalConverter))]
    public decimal Rank10EuroMillionsPrize { get; set; }

    [CsvColumn("nombre_de_gagnant_au_rang11_en_france", "nombre_de_gagnant_au_rang11_Euro_Millions_en_france")]
    public int Rank11EuroMillionsWinnersFrance { get; set; }

    [CsvColumn("nombre_de_gagnant_au_rang11_en_europe", "nombre_de_gagnant_au_rang11_Euro_Millions_en_europe")]
    public int Rank11EuroMillionsWinnersEurope { get; set; }

    [CsvColumn("rapport_du_rang11", "rapport_du_rang11_Euro_Millions")]
    [CsvConverter(typeof(FdjDecimalConverter))]
    public decimal Rank11EuroMillionsPrize { get; set; }

    [CsvColumn("nombre_de_gagnant_au_rang12_en_france", "nombre_de_gagnant_au_rang12_Euro_Millions_en_france")]
    public int Rank12EuroMillionsWinnersFrance { get; set; }

    [CsvColumn("nombre_de_gagnant_au_rang12_en_europe", "nombre_de_gagnant_au_rang12_Euro_Millions_en_europe")]
    public int Rank12EuroMillionsWinnersEurope { get; set; }

    [CsvColumn("rapport_du_rang12", "rapport_du_rang12_Euro_Millions")]
    [CsvConverter(typeof(FdjDecimalConverter))]
    public decimal Rank12EuroMillionsPrize { get; set; }

    [CsvColumn(
        "nombre_de_gagnant_au_rang13_en_france",
        "nombre_de_gagnant_au_rang13_Euro_Millions_en_france",
        Optional = true
    )]
    public int Rank13EuroMillionsWinnersFrance { get; set; }

    [CsvColumn(
        "nombre_de_gagnant_au_rang13_en_europe",
        "nombre_de_gagnant_au_rang13_Euro_Millions_en_europe",
        Optional = true
    )]
    public int Rank13EuroMillionsWinnersEurope { get; set; }

    [CsvColumn("rapport_du_rang13", "rapport_du_rang13_Euro_Millions", Optional = true)]
    [CsvConverter(typeof(FdjDecimalConverter))]
    public decimal Rank13EuroMillionsPrize { get; set; }

    [CsvColumn("nombre_de_gagnant_au_rang1_Etoile+", Optional = true)]
    public int Rank1EtoilePlusWinners { get; set; }

    [CsvColumn("rapport_du_rang1_Etoile+", Optional = true)]
    [CsvConverter(typeof(FdjDecimalConverter))]
    public decimal Rank1EtoilePlusPrize { get; set; }

    [CsvColumn("nombre_de_gagnant_au_rang2_Etoile+", Optional = true)]
    public int Rank2EtoilePlusWinners { get; set; }

    [CsvColumn("rapport_du_rang2_Etoile+", Optional = true)]
    [CsvConverter(typeof(FdjDecimalConverter))]
    public decimal Rank2EtoilePlusPrize { get; set; }

    [CsvColumn("nombre_de_gagnant_au_rang3_Etoile+", Optional = true)]
    public int Rank3EtoilePlusWinners { get; set; }

    [CsvColumn("rapport_du_rang3_Etoile+", Optional = true)]
    [CsvConverter(typeof(FdjDecimalConverter))]
    public decimal Rank3EtoilePlusPrize { get; set; }

    [CsvColumn("nombre_de_gagnant_au_rang4_Etoile+", Optional = true)]
    public int Rank4EtoilePlusWinners { get; set; }

    [CsvColumn("rapport_du_rang4_Etoile+", Optional = true)]
    [CsvConverter(typeof(FdjDecimalConverter))]
    public decimal Rank4EtoilePlusPrize { get; set; }

    [CsvColumn("nombre_de_gagnant_au_rang5_Etoile+", Optional = true)]
    public int Rank5EtoilePlusWinners { get; set; }

    [CsvColumn("rapport_du_rang5_Etoile+", Optional = true)]
    [CsvConverter(typeof(FdjDecimalConverter))]
    public decimal Rank5EtoilePlusPrize { get; set; }

    [CsvColumn("nombre_de_gagnant_au_rang6_Etoile+", Optional = true)]
    public int Rank6EtoilePlusWinners { get; set; }

    [CsvColumn("rapport_du_rang6_Etoile+", Optional = true)]
    [CsvConverter(typeof(FdjDecimalConverter))]
    public decimal Rank6EtoilePlusPrize { get; set; }

    [CsvColumn("nombre_de_gagnant_au_rang7_Etoile+", Optional = true)]
    public int Rank7EtoilePlusWinners { get; set; }

    [CsvColumn("rapport_du_rang7_Etoile+", Optional = true)]
    [CsvConverter(typeof(FdjDecimalConverter))]
    public decimal Rank7EtoilePlusPrize { get; set; }

    [CsvColumn("nombre_de_gagnant_au_rang8_Etoile+", Optional = true)]
    public int Rank8EtoilePlusWinners { get; set; }

    [CsvColumn("rapport_du_rang8_Etoile+", Optional = true)]
    [CsvConverter(typeof(FdjDecimalConverter))]
    public decimal Rank8EtoilePlusPrize { get; set; }

    [CsvColumn("nombre_de_gagnant_au_rang9_Etoile+", Optional = true)]
    public int Rank9EtoilePlusWinners { get; set; }

    [CsvColumn("rapport_du_rang9_Etoile+", Optional = true)]
    [CsvConverter(typeof(FdjDecimalConverter))]
    public decimal Rank9EtoilePlusPrize { get; set; }

    [CsvColumn("nombre_de_gagnant_au_rang10_Etoile+", Optional = true)]
    public int Rank10EtoilePlusWinners { get; set; }

    [CsvColumn("rapport_du_rang10_Etoile+", Optional = true)]
    [CsvConverter(typeof(FdjDecimalConverter))]
    public decimal Rank10EtoilePlusPrize { get; set; }
}

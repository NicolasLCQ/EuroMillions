using CsvHelper.Configuration;

using EuroMillions.Infrastructure.Helpers;
using EuroMillions.Infrastructure.Models.csv;

namespace EuroMillions.Infrastructure.Mappers.CsvMappers;

public sealed class CsvDrawMap : ClassMap<CsvDrawModel>
{
    public CsvDrawMap()
    {
        Map(draw => draw.Ball1).Name("boule_1");
        Map(draw => draw.Ball2).Name("boule_2");
        Map(draw => draw.Ball3).Name("boule_3");
        Map(draw => draw.Ball4).Name("boule_4");
        Map(draw => draw.Ball5).Name("boule_5");
        Map(draw => draw.Star1).Name("etoile_1");
        Map(draw => draw.Star2).Name("etoile_2");

        Map(draw => draw.YearDrawNumber).Name("annee_numero_de_tirage");

        Map(draw => draw.DrawDate)
            .Name("date_de_tirage")
            .TypeConverterOption
            .Format("yyyyMMdd", "dd/MM/yyyy", "dd/MM/yy");

        Map(draw => draw.DrawDay).Name("jour_de_tirage").Optional();

        Map(draw => draw.ForclusionDate)
            .Name("date_de_forclusion")
            .Optional()
            .TypeConverterOption
            .Format("yyyyMMdd", "dd/MM/yyyy", "dd/MM/yy");

        Map(draw => draw.DrawNumberInCycle)
            .Name(
                "num\u00E9ro_de_tirage_dans_le_cycle",
                "num\uFFFDro_de_tirage_dans_le_cycle",
                "num\u00C3\u00A9ro_de_tirage_dans_le_cycle",
                "numero_de_tirage_dans_le_cycle"
            )
            .Optional()
            .Convert(args => StringHelpers.ParseNullableIntOrNull(args.Row.GetField(args.Row.CurrentIndex)));

        Map(draw => draw.WinningBallsInAscendingOrder)
            .Name("boules_gagnantes_en_ordre_croissant")
            .Optional();

        Map(draw => draw.WinningStarsInAscendingOrder)
            .Name("etoiles_gagnantes_en_ordre_croissant")
            .Optional();

        Map(draw => draw.JokerPlusNumber).Name("numero_jokerplus").Optional();
        Map(draw => draw.MyMillionNumber).Name("numero_My_Million").Optional();

        Map(draw => draw.ExceptionalEuroMillionsDrawNumber)
            .Name(
                "numero_Tirage_Exceptionnel_Euro_Million",
                "numero_Tirage_Exceptionnel_Euro_Millions"
            )
            .Optional();

        Map(draw => draw.Currency).Name("devise").Optional();

        Map(draw => draw.Rank1EuroMillionsWinnersFrance)
            .Name(
                "nombre_de_gagnant_au_rang1_en_france",
                "nombre_de_gagnant_au_rang1_Euro_Millions_en_france"
            )
            .Optional();

        Map(draw => draw.Rank1EuroMillionsWinnersEurope)
            .Name(
                "nombre_de_gagnant_au_rang1_en_europe",
                "nombre_de_gagnant_au_rang1_Euro_Millions_en_europe"
            )
            .Optional();

        Map(draw => draw.Rank1EuroMillionsPrize)
            .Name("rapport_du_rang1", "rapport_du_rang1_Euro_Millions")
            .Optional()
            .Convert(args => StringHelpers.ParseNullableDecimal(args.Row.GetField(args.Row.CurrentIndex)));

        Map(draw => draw.Rank2EuroMillionsWinnersFrance)
            .Name(
                "nombre_de_gagnant_au_rang2_en_france",
                "nombre_de_gagnant_au_rang2_Euro_Millions_en_france"
            )
            .Optional();

        Map(draw => draw.Rank2EuroMillionsWinnersEurope)
            .Name(
                "nombre_de_gagnant_au_rang2_en_europe",
                "nombre_de_gagnant_au_rang2_Euro_Millions_en_europe"
            )
            .Optional();

        Map(draw => draw.Rank2EuroMillionsPrize)
            .Name("rapport_du_rang2", "rapport_du_rang2_Euro_Millions")
            .Optional()
            .Convert(args => StringHelpers.ParseNullableDecimal(args.Row.GetField(args.Row.CurrentIndex)));

        Map(draw => draw.Rank3EuroMillionsWinnersFrance)
            .Name(
                "nombre_de_gagnant_au_rang3_en_france",
                "nombre_de_gagnant_au_rang3_Euro_Millions_en_france"
            )
            .Optional();

        Map(draw => draw.Rank3EuroMillionsWinnersEurope)
            .Name(
                "nombre_de_gagnant_au_rang3_en_europe",
                "nombre_de_gagnant_au_rang3_Euro_Millions_en_europe"
            )
            .Optional();

        Map(draw => draw.Rank3EuroMillionsPrize)
            .Name("rapport_du_rang3", "rapport_du_rang3_Euro_Millions")
            .Optional()
            .Convert(args => StringHelpers.ParseNullableDecimal(args.Row.GetField(args.Row.CurrentIndex)));

        Map(draw => draw.Rank4EuroMillionsWinnersFrance)
            .Name(
                "nombre_de_gagnant_au_rang4_en_france",
                "nombre_de_gagnant_au_rang4_Euro_Millions_en_france"
            )
            .Optional();

        Map(draw => draw.Rank4EuroMillionsWinnersEurope)
            .Name(
                "nombre_de_gagnant_au_rang4_en_europe",
                "nombre_de_gagnant_au_rang4_Euro_Millions_en_europe"
            )
            .Optional();

        Map(draw => draw.Rank4EuroMillionsPrize)
            .Name("rapport_du_rang4", "rapport_du_rang4_Euro_Millions")
            .Optional()
            .Convert(args => StringHelpers.ParseNullableDecimal(args.Row.GetField(args.Row.CurrentIndex)));

        Map(draw => draw.Rank5EuroMillionsWinnersFrance)
            .Name(
                "nombre_de_gagnant_au_rang5_en_france",
                "nombre_de_gagnant_au_rang5_Euro_Millions_en_france"
            )
            .Optional();

        Map(draw => draw.Rank5EuroMillionsWinnersEurope)
            .Name(
                "nombre_de_gagnant_au_rang5_en_europe",
                "nombre_de_gagnant_au_rang5_Euro_Millions_en_europe"
            )
            .Optional();

        Map(draw => draw.Rank5EuroMillionsPrize)
            .Name("rapport_du_rang5", "rapport_du_rang5_Euro_Millions")
            .Optional()
            .Convert(args => StringHelpers.ParseNullableDecimal(args.Row.GetField(args.Row.CurrentIndex)));

        Map(draw => draw.Rank6EuroMillionsWinnersFrance)
            .Name(
                "nombre_de_gagnant_au_rang6_en_france",
                "nombre_de_gagnant_au_rang6_Euro_Millions_en_france"
            )
            .Optional();

        Map(draw => draw.Rank6EuroMillionsWinnersEurope)
            .Name(
                "nombre_de_gagnant_au_rang6_en_europe",
                "nombre_de_gagnant_au_rang6_Euro_Millions_en_europe"
            )
            .Optional();

        Map(draw => draw.Rank6EuroMillionsPrize)
            .Name("rapport_du_rang6", "rapport_du_rang6_Euro_Millions")
            .Optional()
            .Convert(args => StringHelpers.ParseNullableDecimal(args.Row.GetField(args.Row.CurrentIndex)));

        Map(draw => draw.Rank7EuroMillionsWinnersFrance)
            .Name(
                "nombre_de_gagnant_au_rang7_en_france",
                "nombre_de_gagnant_au_rang7_Euro_Millions_en_france"
            )
            .Optional();

        Map(draw => draw.Rank7EuroMillionsWinnersEurope)
            .Name(
                "nombre_de_gagnant_au_rang7_en_europe",
                "nombre_de_gagnant_au_rang7_Euro_Millions_en_europe"
            )
            .Optional();

        Map(draw => draw.Rank7EuroMillionsPrize)
            .Name("rapport_du_rang7", "rapport_du_rang7_Euro_Millions")
            .Optional()
            .Convert(args => StringHelpers.ParseNullableDecimal(args.Row.GetField(args.Row.CurrentIndex)));

        Map(draw => draw.Rank8EuroMillionsWinnersFrance)
            .Name(
                "nombre_de_gagnant_au_rang8_en_france",
                "nombre_de_gagnant_au_rang8_Euro_Millions_en_france"
            )
            .Optional();

        Map(draw => draw.Rank8EuroMillionsWinnersEurope)
            .Name(
                "nombre_de_gagnant_au_rang8_en_europe",
                "nombre_de_gagnant_au_rang8_Euro_Millions_en_europe"
            )
            .Optional();

        Map(draw => draw.Rank8EuroMillionsPrize)
            .Name("rapport_du_rang8", "rapport_du_rang8_Euro_Millions")
            .Optional()
            .Convert(args => StringHelpers.ParseNullableDecimal(args.Row.GetField(args.Row.CurrentIndex)));

        Map(draw => draw.Rank9EuroMillionsWinnersFrance)
            .Name(
                "nombre_de_gagnant_au_rang9_en_france",
                "nombre_de_gagnant_au_rang9_Euro_Millions_en_france"
            )
            .Optional();

        Map(draw => draw.Rank9EuroMillionsWinnersEurope)
            .Name(
                "nombre_de_gagnant_au_rang9_en_europe",
                "nombre_de_gagnant_au_rang9_Euro_Millions_en_europe"
            )
            .Optional();

        Map(draw => draw.Rank9EuroMillionsPrize)
            .Name("rapport_du_rang9", "rapport_du_rang9_Euro_Millions")
            .Optional()
            .Convert(args => StringHelpers.ParseNullableDecimal(args.Row.GetField(args.Row.CurrentIndex)));

        Map(draw => draw.Rank10EuroMillionsWinnersFrance)
            .Name(
                "nombre_de_gagnant_au_rang10_en_france",
                "nombre_de_gagnant_au_rang10_Euro_Millions_en_france"
            )
            .Optional();

        Map(draw => draw.Rank10EuroMillionsWinnersEurope)
            .Name(
                "nombre_de_gagnant_au_rang10_en_europe",
                "nombre_de_gagnant_au_rang10_Euro_Millions_en_europe"
            )
            .Optional();

        Map(draw => draw.Rank10EuroMillionsPrize)
            .Name("rapport_du_rang10", "rapport_du_rang10_Euro_Millions")
            .Optional()
            .Convert(args => StringHelpers.ParseNullableDecimal(args.Row.GetField(args.Row.CurrentIndex)));

        Map(draw => draw.Rank11EuroMillionsWinnersFrance)
            .Name(
                "nombre_de_gagnant_au_rang11_en_france",
                "nombre_de_gagnant_au_rang11_Euro_Millions_en_france"
            )
            .Optional();

        Map(draw => draw.Rank11EuroMillionsWinnersEurope)
            .Name(
                "nombre_de_gagnant_au_rang11_en_europe",
                "nombre_de_gagnant_au_rang11_Euro_Millions_en_europe"
            )
            .Optional();

        Map(draw => draw.Rank11EuroMillionsPrize)
            .Name("rapport_du_rang11", "rapport_du_rang11_Euro_Millions")
            .Optional()
            .Convert(args => StringHelpers.ParseNullableDecimal(args.Row.GetField(args.Row.CurrentIndex)));

        Map(draw => draw.Rank12EuroMillionsWinnersFrance)
            .Name(
                "nombre_de_gagnant_au_rang12_en_france",
                "nombre_de_gagnant_au_rang12_Euro_Millions_en_france"
            )
            .Optional();

        Map(draw => draw.Rank12EuroMillionsWinnersEurope)
            .Name(
                "nombre_de_gagnant_au_rang12_en_europe",
                "nombre_de_gagnant_au_rang12_Euro_Millions_en_europe"
            )
            .Optional();

        Map(draw => draw.Rank12EuroMillionsPrize)
            .Name("rapport_du_rang12", "rapport_du_rang12_Euro_Millions")
            .Optional()
            .Convert(args => StringHelpers.ParseNullableDecimal(args.Row.GetField(args.Row.CurrentIndex)));

        Map(draw => draw.Rank13EuroMillionsWinnersFrance)
            .Name(
                "nombre_de_gagnant_au_rang13_en_france",
                "nombre_de_gagnant_au_rang13_Euro_Millions_en_france"
            )
            .Optional();

        Map(draw => draw.Rank13EuroMillionsWinnersEurope)
            .Name(
                "nombre_de_gagnant_au_rang13_en_europe",
                "nombre_de_gagnant_au_rang13_Euro_Millions_en_europe"
            )
            .Optional();

        Map(draw => draw.Rank13EuroMillionsPrize)
            .Name("rapport_du_rang13", "rapport_du_rang13_Euro_Millions")
            .Optional()
            .Convert(args => StringHelpers.ParseNullableDecimal(args.Row.GetField(args.Row.CurrentIndex)));

        Map(draw => draw.Rank1EtoilePlusWinners)
            .Name("nombre_de_gagnant_au_rang1_Etoile+")
            .Optional();

        Map(draw => draw.Rank1EtoilePlusPrize)
            .Name("rapport_du_rang1_Etoile+")
            .Optional()
            .Convert(args => StringHelpers.ParseNullableDecimal(args.Row.GetField(args.Row.CurrentIndex)));

        Map(draw => draw.Rank2EtoilePlusWinners)
            .Name("nombre_de_gagnant_au_rang2_Etoile+")
            .Optional();

        Map(draw => draw.Rank2EtoilePlusPrize)
            .Name("rapport_du_rang2_Etoile+")
            .Optional()
            .Convert(args => StringHelpers.ParseNullableDecimal(args.Row.GetField(args.Row.CurrentIndex)));

        Map(draw => draw.Rank3EtoilePlusWinners)
            .Name("nombre_de_gagnant_au_rang3_Etoile+")
            .Optional();

        Map(draw => draw.Rank3EtoilePlusPrize)
            .Name("rapport_du_rang3_Etoile+")
            .Optional()
            .Convert(args => StringHelpers.ParseNullableDecimal(args.Row.GetField(args.Row.CurrentIndex)));

        Map(draw => draw.Rank4EtoilePlusWinners)
            .Name("nombre_de_gagnant_au_rang4_Etoile+")
            .Optional();

        Map(draw => draw.Rank4EtoilePlusPrize)
            .Name("rapport_du_rang4_Etoile+")
            .Optional()
            .Convert(args => StringHelpers.ParseNullableDecimal(args.Row.GetField(args.Row.CurrentIndex)));

        Map(draw => draw.Rank5EtoilePlusWinners)
            .Name("nombre_de_gagnant_au_rang5_Etoile+")
            .Optional();

        Map(draw => draw.Rank5EtoilePlusPrize)
            .Name("rapport_du_rang5_Etoile+")
            .Optional()
            .Convert(args => StringHelpers.ParseNullableDecimal(args.Row.GetField(args.Row.CurrentIndex)));

        Map(draw => draw.Rank6EtoilePlusWinners)
            .Name("nombre_de_gagnant_au_rang6_Etoile+")
            .Optional();

        Map(draw => draw.Rank6EtoilePlusPrize)
            .Name("rapport_du_rang6_Etoile+")
            .Optional()
            .Convert(args => StringHelpers.ParseNullableDecimal(args.Row.GetField(args.Row.CurrentIndex)));

        Map(draw => draw.Rank7EtoilePlusWinners)
            .Name("nombre_de_gagnant_au_rang7_Etoile+")
            .Optional();

        Map(draw => draw.Rank7EtoilePlusPrize)
            .Name("rapport_du_rang7_Etoile+")
            .Optional()
            .Convert(args => StringHelpers.ParseNullableDecimal(args.Row.GetField(args.Row.CurrentIndex)));

        Map(draw => draw.Rank8EtoilePlusWinners)
            .Name("nombre_de_gagnant_au_rang8_Etoile+")
            .Optional();

        Map(draw => draw.Rank8EtoilePlusPrize)
            .Name("rapport_du_rang8_Etoile+")
            .Optional()
            .Convert(args => StringHelpers.ParseNullableDecimal(args.Row.GetField(args.Row.CurrentIndex)));

        Map(draw => draw.Rank9EtoilePlusWinners)
            .Name("nombre_de_gagnant_au_rang9_Etoile+")
            .Optional();

        Map(draw => draw.Rank9EtoilePlusPrize)
            .Name("rapport_du_rang9_Etoile+")
            .Optional()
            .Convert(args => StringHelpers.ParseNullableDecimal(args.Row.GetField(args.Row.CurrentIndex)));

        Map(draw => draw.Rank10EtoilePlusWinners)
            .Name("nombre_de_gagnant_au_rang10_Etoile+")
            .Optional();

        Map(draw => draw.Rank10EtoilePlusPrize)
            .Name("rapport_du_rang10_Etoile+")
            .Optional()
            .Convert(args => StringHelpers.ParseNullableDecimal(args.Row.GetField(args.Row.CurrentIndex)));
    }
}

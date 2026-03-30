namespace EuroMillions.Application.Consts;

public static class FdjHistoryLinksConsts
{
    public const string HistoryPageUrl = "https://www.fdj.fr/jeux-de-tirage/euromillions-my-million/historique";
    public const string HistoryFileLinkPattern =
        "^https://www\\.sto\\.api\\.fdj\\.fr/anonymous/service-draw-info/v3/documentations/[a-zA-Z0-9-]+$";
}

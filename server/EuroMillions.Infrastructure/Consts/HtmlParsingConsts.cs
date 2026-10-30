namespace EuroMillions.Infrastructure.Consts;

public static class HtmlParsingConsts
{
    public const string HrefPattern = "\\bhref\\s*=\\s*\"(?<href>[^\"]+)\"|\\bhref\\s*=\\s*'(?<href>[^']+)'";
}

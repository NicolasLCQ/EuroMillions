namespace EuroMillions.Infrastructure.Models;

public class FdjMoneyAmount
{
    public required decimal Value { get; set; }
    public required string Currency { get; set; }
    public required int Scale { get; set; }
}

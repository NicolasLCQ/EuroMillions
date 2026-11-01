using System.Text.Json.Serialization;

namespace EuroMillions.Infrastructure.Models;

public class FdjDrawInfo
{
    [JsonPropertyName("is_current")]
    public required bool IsCurrent { get; set; }

    [JsonPropertyName("estimated_jackpot")]
    public required List<FdjMoneyAmount> EstimatedJackpot { get; set; }
}

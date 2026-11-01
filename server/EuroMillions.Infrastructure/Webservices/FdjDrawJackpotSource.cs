using System.Net.Http.Json;
using System.Text.Json;

using EuroMillions.Application.Interfaces.Infrastructure.Webservices;
using EuroMillions.Application.Models;
using EuroMillions.Infrastructure.Consts;
using EuroMillions.Infrastructure.Helpers;
using EuroMillions.Infrastructure.Mappers.ModelMappers;
using EuroMillions.Infrastructure.Models;

namespace EuroMillions.Infrastructure.Webservices;

public class FdjDrawJackpotSource(HttpClient httpClient) : IDrawJackpotSource
{
    public async Task<EstimatedJackpotModel?> GetNextDrawEstimatedJackpotAsync(CancellationToken cancellationToken = default)
    {
        using HttpRequestMessage request = HttpHelper.CreateHttpRequest(FdjConsts.CurrentDrawsUrl, "application/json");
        using HttpResponseMessage response = await httpClient.SendAsync(request, cancellationToken);
        response.EnsureSuccessStatusCode();

        List<FdjDrawInfo> draws = await response.Content.ReadFromJsonAsync<List<FdjDrawInfo>>(cancellationToken)
            ?? throw new JsonException("The draw service returned an invalid response.");

        FdjMoneyAmount? jackpot = draws.FirstOrDefault(draw => draw.IsCurrent)
            ?.EstimatedJackpot.FirstOrDefault(amount => amount.Currency == "EUR");

        return jackpot?.ToEstimatedJackpotModel();
    }
}

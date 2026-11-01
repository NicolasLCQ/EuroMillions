using EuroMillions.Application.Models;

namespace EuroMillions.Application.Interfaces.Infrastructure.Webservices;

public interface IDrawJackpotSource
{
    /// <summary>Gets the current draw's estimated jackpot in euros.</summary>
    /// <param name="cancellationToken">Cancels the external request.</param>
    /// <returns>The estimated jackpot, or null when no current draw or euro amount is available.</returns>
    /// <exception cref="HttpRequestException">The external request fails.</exception>
    /// <exception cref="OperationCanceledException">The request is cancelled or times out.</exception>
    Task<EstimatedJackpotModel?> GetNextDrawEstimatedJackpotAsync(CancellationToken cancellationToken = default);
}

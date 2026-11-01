using EuroMillions.Application.Models;

namespace EuroMillions.Application.UseCases;

public partial class DrawUseCases
{
    public Task<EstimatedJackpotModel?> GetNextDrawEstimatedJackpotAsync(CancellationToken cancellationToken = default)
    {
        return drawJackpotSource.GetNextDrawEstimatedJackpotAsync(cancellationToken);
    }
}

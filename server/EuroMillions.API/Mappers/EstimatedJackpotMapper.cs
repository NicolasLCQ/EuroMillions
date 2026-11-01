using EuroMillions.API.ViewModels;
using EuroMillions.Application.Models;

namespace EuroMillions.API.Mappers;

public static class EstimatedJackpotMapper
{
    public static EstimatedJackpotResponseViewModel ToEstimatedJackpotResponseViewModel(this EstimatedJackpotModel jackpot)
    {
        return new EstimatedJackpotResponseViewModel {Amount = jackpot.Amount, Currency = jackpot.Currency};
    }
}

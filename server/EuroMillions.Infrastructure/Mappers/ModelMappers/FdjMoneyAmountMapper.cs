using EuroMillions.Application.Models;
using EuroMillions.Infrastructure.Models;

namespace EuroMillions.Infrastructure.Mappers.ModelMappers;

public static class FdjMoneyAmountMapper
{
    public static EstimatedJackpotModel ToEstimatedJackpotModel(this FdjMoneyAmount amount)
    {
        return new EstimatedJackpotModel
        {
            Amount = amount.Value / (decimal)Math.Pow(10, amount.Scale),
            Currency = amount.Currency
        };
    }
}

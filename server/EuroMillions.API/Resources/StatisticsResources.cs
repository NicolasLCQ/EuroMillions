using EuroMillions.API.Validators;
using EuroMillions.API.ViewModels;
using EuroMillions.Application.Interfaces.UseCases;

namespace EuroMillions.API.Resources;

public class StatisticsResources(
    IDrawUseCases drawUseCases,
    IBallValidator ballValidator,
    IStarValidator starValidator
)
{
    public async Task<IResult> GetBallNbTimePickedAsync(int ballNumber)
    {
        ballValidator.Validate(ballNumber);

        int nbTimePicked = await drawUseCases.GetBallNbTimePickedAsync(ballNumber);

        return Results.Ok(new NbTimePickedResponseViewModel {NbTimePicked = nbTimePicked});
    }

    public async Task<IResult> GetAllBallsNbTimePickedAsync()
    {
        Dictionary<int, int> nbTimePickedByBall = await drawUseCases.GetAllBallsNbTimePickedAsync();

        return Results.Ok(ToAllNbTimePickedResponseViewModels(nbTimePickedByBall));
    }

    public async Task<IResult> GetStarNbTimePickedAsync(int starNumber)
    {
        starValidator.Validate(starNumber);

        int nbTimePicked = await drawUseCases.GetStarNbTimePickedAsync(starNumber);

        return Results.Ok(new NbTimePickedResponseViewModel {NbTimePicked = nbTimePicked});
    }

    public async Task<IResult> GetAllStarsNbTimePickedAsync()
    {
        Dictionary<int, int> nbTimePickedByStar = await drawUseCases.GetAllStarsNbTimePickedAsync();

        return Results.Ok(ToAllNbTimePickedResponseViewModels(nbTimePickedByStar));
    }

    private static List<AllNbTimePickedResponseViewModel> ToAllNbTimePickedResponseViewModels(
        Dictionary<int, int> nbTimePickedByNumber
    ) =>
        nbTimePickedByNumber
            .OrderBy(item => item.Key)
            .Select(item => new AllNbTimePickedResponseViewModel
                {
                    Number = item.Key,
                    NbTimePicked = item.Value
                }
            )
            .ToList();
}

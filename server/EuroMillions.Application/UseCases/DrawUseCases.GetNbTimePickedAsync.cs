namespace EuroMillions.Application.UseCases;

public partial class DrawUseCases
{
    public async Task<Dictionary<int, int>> GetAllBallsNbTimePickedAsync() =>
        await drawRepository.GetAllBallsNbTimePickedAsync();

    public async Task<Dictionary<int, int>> GetAllStarsNbTimePickedAsync() =>
        await drawRepository.GetAllStarsNbTimePickedAsync();
}

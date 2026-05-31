namespace EuroMillions.Application.UseCases;

public partial class DrawUseCases
{
    public async Task<int> GetBallNbTimePickedAsync(int ballNumber) =>
        await drawRepository.GetBallNbTimePickedAsync(ballNumber);

    public async Task<int> GetStarNbTimePickedAsync(int starNumber) =>
        await drawRepository.GetStarNbTimePickedAsync(starNumber);

    public async Task<Dictionary<int, int>> GetAllBallsNbTimePickedAsync() =>
        await drawRepository.GetAllBallsNbTimePickedAsync();

    public async Task<Dictionary<int, int>> GetAllStarsNbTimePickedAsync() =>
        await drawRepository.GetAllStarsNbTimePickedAsync();
}

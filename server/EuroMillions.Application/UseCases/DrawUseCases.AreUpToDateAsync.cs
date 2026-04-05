namespace EuroMillions.Application.UseCases;

public partial class DrawUseCases
{
    public async Task<bool> AreUpToDateAsync() => await drawRepository.AreDrawsUpToDateAsync();
}

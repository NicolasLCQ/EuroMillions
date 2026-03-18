namespace EuroMillions.Application.UseCases;

public partial class DrawUseCases
{
    public async Task<bool> AreUpToDate() => await drawRepository.AreDrawsUpToDateAsync();
}

using EuroMillions.Application.Models;

namespace EuroMillions.Application.UseCases;

public partial class DrawUseCases
{
    public async Task<Draw?> GetLastDrawAsync() => await drawRepository.GetLastDrawAsync();
}

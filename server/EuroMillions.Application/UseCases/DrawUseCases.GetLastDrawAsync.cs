using EuroMillions.Application.Models;

namespace EuroMillions.Application.UseCases;

public partial class DrawUseCases
{
    public async Task<DrawSummaryModel?> GetLastDrawAsync() => await drawRepository.GetLastDrawAsync();
}

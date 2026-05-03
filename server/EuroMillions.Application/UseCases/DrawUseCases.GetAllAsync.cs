using EuroMillions.Application.Models;

namespace EuroMillions.Application.UseCases;

public partial class DrawUseCases
{
    public async Task<List<DrawSummaryModel>> GetAllAsync() => await drawRepository.GetAllDrawsAsync();
}

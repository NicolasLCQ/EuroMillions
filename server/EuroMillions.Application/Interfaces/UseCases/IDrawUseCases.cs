using EuroMillions.Application.Models;
using EuroMillions.Application.Models.Upload;

namespace EuroMillions.Application.Interfaces.UseCases;

public interface IDrawUseCases
{
    Task<DrawItemsStatisticsModel> GetStatisticsAsync();
    Task<UploadResultModel> UploadDrawsFromCsvFilesAsync(IReadOnlyCollection<UploadFileModel> uploadFileModels);
    Task<DrawSummaryModel?> GetLastDrawAsync();
    Task<DateTime> GetNextDrawDateAsync();
    /// <summary>Gets the current draw's estimated euro jackpot, or null when unavailable.</summary>
    /// <param name="cancellationToken">Cancels the external request.</param>
    /// <returns>The estimated jackpot when supplied by the draw source.</returns>
    Task<EstimatedJackpotModel?> GetNextDrawEstimatedJackpotAsync(CancellationToken cancellationToken = default);
    Task<bool> AreUpToDateAsync();
    Task<UploadResultModel> UpdateAutomaticallyAsync();
    Task<List<DrawSummaryModel>> GetAllAsync();
}

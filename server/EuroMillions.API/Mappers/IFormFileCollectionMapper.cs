namespace EuroMillions.API.Mappers;

using Application.Models;

public static class FormFileMapper
{
    public static UploadFileModel ToUploadFileModel(this IFormFile file) => new() { FileName = file.FileName, FileSream = file.OpenReadStream() };
}

namespace EuroMillions.API.Mappers;

using Data.Models;

public static class IFormFileMapper
{
    public static UploadFileModel ToUploadFileModel(this IFormFile file)
    {
        return new UploadFileModel { FileName = file.FileName, FileSream = file.OpenReadStream() };
    }
}

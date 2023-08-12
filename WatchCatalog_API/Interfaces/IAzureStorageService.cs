namespace WatchCatalog_API.Interfaces
{
    public interface IAzureStorageService
    {
        Task<string> UploadAsync(IFormFile image);

        Task DeleteAsync(string imageName);

        Task RestoreAsync(string imageName);
    }
}

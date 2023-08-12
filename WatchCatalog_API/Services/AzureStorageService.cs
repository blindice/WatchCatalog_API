using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using WatchCatalog_API.Interfaces;

namespace WatchCatalog_API.Services
{
    public class AzureStorageService : IAzureStorageService
    {
        readonly BlobServiceClient _blobService;
        readonly IConfiguration _config;
        readonly string _containerUri;
        readonly BlobContainerClient _containerClient;

        public AzureStorageService(BlobServiceClient blobService, IConfiguration config)
        {
            _blobService = blobService ?? throw new NullReferenceException();
            _config = config;
            _containerClient = _blobService.GetBlobContainerClient(_config["Blob:Container:Name"]);
            _containerUri = $"{_containerClient.Uri.AbsoluteUri}/";
        }

        public async Task<string> UploadAsync(IFormFile image)
        {
            await _containerClient.CreateIfNotExistsAsync(PublicAccessType.Blob);
            var newBlobname = $"{Guid.NewGuid().ToString()}.jpg";
            await _containerClient.UploadBlobAsync(newBlobname, image.OpenReadStream());
            var imageUrl = $"{_containerUri}{newBlobname}";

            return imageUrl;
        }

        public async Task DeleteAsync(string imageName)
        {
            var modifiedImageName = imageName.Replace(_containerUri, string.Empty);
            var image = _containerClient.GetBlobClient(modifiedImageName);

            await image.DeleteIfExistsAsync();
        }

        public async Task RestoreAsync(string imageName)
        {
            var modifiedImageName = imageName.Replace(_containerUri, string.Empty);
            var image = _containerClient.GetBlobClient(modifiedImageName);

            await image.UndeleteAsync();
        }
    }
}

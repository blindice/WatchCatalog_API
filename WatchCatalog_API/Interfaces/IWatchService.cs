using WatchCatalog_API.DTOs;

namespace WatchCatalog_API.Interfaces
{
    public interface IWatchService
    {
        Task<List<WatchDTO>> GetWatchesAsync(CancellationToken cancellationToken);

        Task<WatchDetailsDTO> GetWatchAsync(int id, CancellationToken cancellationToken);

        Task<WatchDetailsDTO> UpdateWatchAsync(UpdateWatchDTO watch, CancellationToken cancellationToken);

        Task<WatchDetailsDTO> CreateWatchAsync(CreateWatchDTO watch);

        Task<WatchDetailsDTO> ToggleWatchAsync(ToggleWatchDTO watch, CancellationToken cancellationToken);

        Task<WatchDetailsDTO> DeleteWatchAsync(int id, CancellationToken cancellationToken);
    }
}

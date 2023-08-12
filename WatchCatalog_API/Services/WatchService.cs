using AutoMapper;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing;
using System.Threading;
using WatchCatalog_API.DTOs;
using WatchCatalog_API.Interfaces;
using WatchCatalog_API.Model;

namespace WatchCatalog_API.Services
{
    public class WatchService : IWatchService
    {
        readonly IWatchRepository _repo;
        readonly IAzureStorageService _storageService;
        readonly IMapper _mapper;

        public WatchService(IWatchRepository repo, IAzureStorageService storageService, IMapper mapper)
        {
            _repo = repo ?? throw new NullReferenceException();
            _storageService = storageService ?? throw new NullReferenceException();
            _mapper = mapper ?? throw new NullReferenceException();
        }

        public async Task<List<WatchDTO>> GetWatchesAsync(CancellationToken cancellationToken)
        {
            List<WatchDTO> watches = await _repo.GetWatches()
                                                .Select(w => new WatchDTO
                                                {
                                                    WatchId = w.WatchId,
                                                    Image = w.Image,
                                                    Price = w.Price,
                                                    Short_description = w.Short_description,
                                                    IsActive = w.IsActive
                                                })
                                                .ToListAsync(cancellationToken);

            return watches;
        }

        public async Task<WatchDetailsDTO> GetWatchAsync(int id, CancellationToken cancellationToken)
        {
            tbl_watch? watch = await _repo.GetWatchByIdAsync((int)id, cancellationToken);
            var watcheDTO = _mapper.Map<WatchDetailsDTO>(watch);

            return watcheDTO;
        }

        #region Update Watch
        public async Task<WatchDetailsDTO> UpdateWatchAsync(UpdateWatchDTO watch, CancellationToken cancellationToken)
        {
            bool isDeleted = false;
            bool isUpdated = false;
            string deletedImageName = string.Empty;
            string updatedImageName = string.Empty;
            try
            {
                tbl_watch? verifiedWatch = await _repo.GetWatchByIdAsync(watch.WatchId, cancellationToken);

                if (verifiedWatch == null) throw new NullReferenceException("Watch to Update Not Found!");

                var modifiedWatch = _mapper.Map<tbl_watch>(watch);


                if (!string.IsNullOrEmpty(verifiedWatch.Image))
                {
                    await _storageService.DeleteAsync(verifiedWatch.Image);
                    deletedImageName = verifiedWatch.Image;
                    isDeleted = true;
                }

                if (watch.Image != null)
                {
                    modifiedWatch.Image = await _storageService.UploadAsync(watch.Image);
                    updatedImageName = modifiedWatch.Image;
                    isUpdated = true;
                }


                await _repo.UpdateWatchAsync(modifiedWatch);
                var resultWatch = _mapper.Map<WatchDetailsDTO>(modifiedWatch);

                return resultWatch;
            }
            catch (Exception)
            {
                if (isDeleted)
                    await _storageService.RestoreAsync(deletedImageName);

                if (isUpdated)
                    await _storageService.DeleteAsync(updatedImageName);

                throw;
            }
        }
        #endregion

        #region Create Watch
        public async Task<WatchDetailsDTO> CreateWatchAsync(CreateWatchDTO watch)
        {
            bool isAdded = false;
            string createdImageName = string.Empty;
            try
            {
                var newWatch = _mapper.Map<tbl_watch>(watch);

                if (watch.Image != null)
                {
                    newWatch.Image = await _storageService.UploadAsync(watch.Image);
                    createdImageName = newWatch.Image;
                    isAdded = true;
                }

                var result = await _repo.AddWatchAsync(newWatch);

                var resultWatch = _mapper.Map<WatchDetailsDTO>(result);

                return resultWatch;
            }
            catch (Exception)
            {
                if (isAdded)
                    await _storageService.DeleteAsync(createdImageName);

                throw;
            }
        }
        #endregion

        public async Task<WatchDetailsDTO> ToggleWatchAsync(ToggleWatchDTO watch, CancellationToken cancellationToken)
        {
            tbl_watch? verifiedWatch = await _repo.GetWatchByIdAsync(watch.WatchId, cancellationToken);

            if (verifiedWatch == null) throw new NullReferenceException("Watch to Toggle Not Found!");

            verifiedWatch.IsActive = watch.IsActive;

            await _repo.UpdateWatchAsync(verifiedWatch);
            var resultWatch = _mapper.Map<WatchDetailsDTO>(verifiedWatch);

            return resultWatch;
        }
    }
}

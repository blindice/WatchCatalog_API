using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using WatchCatalog_API.DTOs;
using WatchCatalog_API.Filters;
using WatchCatalog_API.Interfaces;
using WatchCatalog_API.Model;
using WatchCatalog_API.Services;

namespace WatchCatalog_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WatchController : ControllerBase
    {
        readonly IWatchService _service;

        public WatchController(IWatchService service)
        {
            _service = service;
        }

        [HttpGet("getwatches")]
        public async Task<IActionResult> GetWatchesAsync(CancellationToken cancellationToken)
        {
            List<WatchDTO> watches = await _service.GetWatchesAsync(cancellationToken);
            return Ok(watches);
        }

        [HttpGet("getwatchbyid/{id}")]
        [ValidationFilterAttribute]
        public async Task<IActionResult> GetWatchByIdAsync(int? id, CancellationToken cancellationToken)
        {
            WatchDetailsDTO? watch = await _service.GetWatchAsync((int)id!, cancellationToken);

            if (watch == null) return NotFound();

            return Ok(watch);
        }

        [HttpPut("updatewatch")]
        [ValidationFilterAttribute]
        public async Task<IActionResult> UpdateWatchAsync([FromForm] UpdateWatchDTO watch, CancellationToken cancellationToken)
        {
            WatchDetailsDTO watchResult = await _service.UpdateWatchAsync(watch, cancellationToken);

            return Ok(watchResult);
        }

        [HttpPost("createwatch")]
        [ValidationFilterAttribute]
        public async Task<IActionResult> CreateWatchAsync([FromForm] CreateWatchDTO watch)
        {
            //await _repo.AddWatchAsync(watch);
            var result = await _service.CreateWatchAsync(watch);

            return Ok(result);
        }


        [HttpPost("togglewatch")]
        public async Task<IActionResult> ToggleWatch([FromBody]ToggleWatchDTO watch, CancellationToken cancellationToken)
        {
            WatchDetailsDTO watchResult = await _service.ToggleWatchAsync(watch, cancellationToken);

            return Ok(watchResult);
        }
    }
}

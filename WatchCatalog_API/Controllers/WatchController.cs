using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WatchCatalog_API.DTOs;
using WatchCatalog_API.Filters;
using WatchCatalog_API.Interfaces;
using WatchCatalog_API.Model;

namespace WatchCatalog_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WatchController : ControllerBase
    {
        readonly IWatchRepository _repo;

        public WatchController(IWatchRepository repo) => _repo = repo;

        [HttpGet("getwatches")]
        public async Task<IActionResult> GetWatchesAsync(CancellationToken cancellationToken)
        {
            List<tbl_watch> watches = await _repo.GetWatches().ToListAsync(cancellationToken);
            return Ok(watches);
        }

        [HttpGet("getwatchbyid/{id}")]
        [ValidationFilterAttribute]
        public async Task<IActionResult> GetWatchByIdAsync(int? id, CancellationToken cancellationToken)
        {
            tbl_watch? watch = await _repo.GetWatchByIdAsync((int)id, cancellationToken);

            if (watch == null) return NotFound();

           return Ok(watch);
        }

        [HttpPut("updatewatch")]
        [ValidationFilterAttribute]
        public async Task<IActionResult> UpdateWatchAsync([FromBody]tbl_watch watch, CancellationToken cancellationToken)
        {
            tbl_watch? validatedWatch = await _repo.GetWatchByIdAsync(watch.WatchId, cancellationToken);

            //if (validatedWatch == null) return NotFound();

            await _repo.UpdateWatchAsync(watch);

            return Ok(watch);
        }

        [HttpPost("createwatch")]
        [ValidationFilterAttribute]
        public async Task<IActionResult> CreateWatchAsync([FromForm]CreateWatchDTO watch)
        {
            //await _repo.AddWatchAsync(watch);

            return Ok(watch);
        }

    }
}

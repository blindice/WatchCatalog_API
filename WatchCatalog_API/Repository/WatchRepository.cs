using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WatchCatalog_API.Context;
using WatchCatalog_API.Interfaces;
using WatchCatalog_API.Model;

namespace WatchCatalog_API.Repository
{
    public class WatchRepository : IWatchRepository
    {
        readonly WatchContext _context;

        public WatchRepository(WatchContext context) => _context = context;

        public IQueryable<tbl_watch> GetWatches() => _context.tbl_watches.AsNoTracking();

        public IQueryable<tbl_watch> GetWatchByCondition(Expression<Func<tbl_watch, bool>> expression)
        {
            return _context.tbl_watches.Where(expression).AsNoTracking();
        }

        public async Task<tbl_watch?> GetWatchByIdAsync(int id, CancellationToken cancellation)
        {
            return await _context.tbl_watches.Where(w => w.WatchId == id).FirstOrDefaultAsync(cancellation);
        }

        public async Task UpdateWatchAsync(tbl_watch watch)
        {
            _context.tbl_watches.Update(watch);
            await _context.SaveChangesAsync();
        }

        public async Task AddWatchAsync(tbl_watch watch)
        {
            _context.tbl_watches.Add(watch);
            await _context.SaveChangesAsync();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WatchCatalog_API.Context;
using WatchCatalog_API.Model;

namespace WatchCatalog_API.Interfaces
{
    public interface IWatchRepository
    {
        IQueryable<tbl_watch> GetWatches();

        IQueryable<tbl_watch> GetWatchByCondition(Expression<Func<tbl_watch, bool>> expression);

        Task<tbl_watch?> GetWatchByIdAsync(int id, CancellationToken cancellation);

        Task UpdateWatchAsync(tbl_watch watch);

        Task<tbl_watch> AddWatchAsync(tbl_watch watch);
    }
}

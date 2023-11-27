using Microsoft.EntityFrameworkCore;
using School.Filters;

namespace School.Tools
{
    public class Paginator<T> where T : class
    {
        public static async Task<PaginatorResponse<List<T>>> Get(DbSet<T> dbSet,PaginationFilter filter )
        {
            var data = await dbSet.Skip((filter.Page - 1) * filter.PageSize)
                .Take(filter.PageSize).ToListAsync();
            var total = await dbSet.CountAsync();
            return new PaginatorResponse<List<T>>(data, filter.Page, filter.PageSize, total);
        }

        public static async Task<PaginatorResponse<List<T>>> Get(IQueryable<T> query, PaginationFilter filter)
        {
            var data = await query.Skip((filter.Page - 1) * filter.PageSize)
                .Take(filter.PageSize).ToListAsync();
            var total = await query.CountAsync();
            return new PaginatorResponse<List<T>>(data, filter.Page, filter.PageSize, total);
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.DTOs;
using School.Filters;
using School.Models;
using School.Tools;

namespace School.Controllers
{
    public class BaseController<T>: ControllerBase where T: class 
    {
        private readonly DbSet<T> dbSet;
        private readonly DatabaseContext context;
        public IMapper mapper { get; }

        public BaseController(DatabaseContext context, DbSet<T> dbSet, IMapper mapper)
        {
            this.dbSet = dbSet;
            this.mapper = mapper;
            this.context = context;
        }

        [NonAction]
        public async Task<ActionResult> GetPaginator(PaginationFilter filter)
        {
            var paginator = await Paginator<T>.Get(dbSet, filter!);
            return Ok(paginator);
        }

        [NonAction]
        public async Task<ActionResult> Destroy(int id, string successText = "Item deleted", string errorText = "Item not found")
        {
            var item = await dbSet.FindAsync(id);
            if (item == null)
            {
                return NotFound(errorText);
            }
            dbSet.Remove(item);
            await context.SaveChangesAsync();
            
            return Ok(new Response<T> { 
                Succeeded = true,
                Data = item,
                Message = successText
            });
        }

        [NonAction]
        public async Task<ActionResult> Store<SOURCE>(SOURCE createPeriod)
        {
            var period = mapper.Map<T>(createPeriod);
            dbSet.Add(period);
            await context.SaveChangesAsync();
            return Ok();
        }

        [NonAction]
        public async Task<ActionResult> Update<SOURCE>(int id, SOURCE createPeriodDto, string text = "Item updated")
        {
            var period = await dbSet.FindAsync(id);
            if (period == null)
            {
                return NotFound("Not found");
            }
            mapper.Map<SOURCE, T>(createPeriodDto, period);
            await context.SaveChangesAsync();
            return Ok(new Response<Period> { 
                Succeeded = true 
            });
        }
    }
}

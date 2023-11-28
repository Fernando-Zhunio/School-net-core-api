using AutoMapper;
using Elfie.Serialization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
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
        public async Task<ActionResult> GetItem(int id)
        {
            var item = await dbSet.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
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
        public async Task<ActionResult> Store<SOURCE>(SOURCE createItem, string actionName = "Get")
        {
            var item = mapper.Map<T>(createItem);
            dbSet.Add(item);
            var _item = item;
            await context.SaveChangesAsync();
            return CreatedAtAction(actionName, new { id = _item.GetType().GetProperty("Id").GetValue(item) }, item);
        }

        [NonAction]
        public async Task<ActionResult> Update<SOURCE>(int id, SOURCE updateDto, string text = "Item updated")
        {
            var period = await dbSet.FindAsync(id);
            if (period == null)
            {
                return NotFound("Not found");
            }
            mapper.Map<SOURCE, T>(updateDto, period);
            await context.SaveChangesAsync();
            return Ok(new Response<Period> { 
                Succeeded = true,
                Message = text
            });
        }

        [NonAction]
        public async Task<ActionResult> UpdatePut<S>(int id, S updateDto, string text = "Item updated")
        {
            
            var item = mapper.Map<S, T>(updateDto);
            item.GetType().GetProperty("Id").SetValue(item, id);
            context.Entry(item).State = EntityState.Modified;
             try
            {
                await context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException)
            {
                var period = await dbSet.FindAsync(id);
                if (period == null)
                {
                    return NotFound("Not found");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();

            //var period = await dbSet.FindAsync(id);
            //if (period == null)
            //{
            //    return NotFound("Not found");
            //}
            //mapper.Map<SOURCE, T>(updateDto, period);
            //await context.SaveChangesAsync();
            //return Ok(new Response<Period>
            //{
            //    Succeeded = true,
            //    Message = text
            //});
        }

    }

    public interface IWithId
    {
        public int Id { set; get; }
    }

}

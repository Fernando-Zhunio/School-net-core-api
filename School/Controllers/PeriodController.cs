using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.DTOs;
using School.Filters;
using School.Models;
using School.Tools;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace School.Controllers
{
    [Route("api/period")]
    [ApiController]
    public class PeriodController : BaseController<Period>
    {
        DatabaseContext db;
        private readonly IMapper mapper;

        public PeriodController(DatabaseContext databaseContext, IMapper mapper): base(databaseContext, databaseContext.Periods, mapper) { 
            this.db = databaseContext;
            this.mapper = mapper;
        }

        // GET: api/<PeriodController>
        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] PaginationFilter filter)
        {
            //var paginator = await Paginator<Period>.Get(db.Periods, filter);
            return await GetPaginator(filter);
        }

        // GET api/period/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var period = await db.Periods.FirstOrDefaultAsync(x => x.Id == id);
            if (period == null)
            {
                return NotFound();
            }
            return Ok(new Response<Period>
            {
                Data = period,
                Succeeded = true
            });
            
        }

        // POST api/period
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreatePeriodDto createPeriod)
        {
            return await Store<CreatePeriodDto>(createPeriod);
        }

        // PUT api/period/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] CreatePeriodDto createPeriodDto )
        {
            return await Update<CreatePeriodDto>(id, createPeriodDto);
        }

        // DELETE api/<PeriodController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        { 
            return await Destroy(id, "Period deleted"); 
        }

    }
}

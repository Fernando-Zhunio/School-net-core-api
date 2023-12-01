using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School.DTOs;
using School.Filters;
using School.Models;

namespace School.Controllers
{
    [Route("api/partials")]
    [ApiController]
    [Authorize]
    public class PartialController : BaseController<Partial>
    {
        private readonly DatabaseContext _context;

        public PartialController(DatabaseContext context, IMapper mapper): base(context, context.Partials, mapper)
        {
            _context = context;
        }

        // GET: api/Partial
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Partial>>> GetPartials([FromQuery] PaginationFilter filter)
        {
            return await GetPaginator(filter);
        }

        // GET: api/Partial/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Partial>> GetPartial(int id)
        {
            return await GetItem(id);
        }

        // PUT: api/Partial/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPartial(int id, CreatePartialDto createPartial)
        {
            return await Update<CreatePartialDto>(id, createPartial);
        }

        // POST: api/Partial
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Partial>> PostPartial(CreatePartialDto createPartial)
        {
            return await Store<CreatePartialDto>(createPartial, "GetPartial");
        }

        // DELETE: api/Partial/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePartial(int id)
        {
            return await Destroy(id);
        }

    }
}

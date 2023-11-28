using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using School.DTOs;
using School.Filters;
using School.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace School.Controllers
{
    [Route("api/notes")]
    [ApiController]
    public class NoteController : BaseController<Note>
    {

        public NoteController(DatabaseContext context, IMapper mapper): base(context, context.Notes, mapper)
        {
            
        }
        // GET: api/<NoteController>
        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] PaginationFilter filter)
        {
            return await GetPaginator(filter);
        }

        // GET api/<NoteController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<NoteController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateNoteDto createNoteDto)
        {
            return await Store<CreateNoteDto>(createNoteDto, "Get");
        }

        // PUT api/<NoteController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] CreateNoteDto value)
        {
            return await Update(id, value);
        }

        // DELETE api/<NoteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

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
        private DatabaseContext context;
        public NoteController(DatabaseContext context, IMapper mapper): base(context, context.Notes, mapper)
        {
            this.context = context;
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

        [HttpGet("period/{id}/students/{studentId}/partials/{partialId}")]
        public async Task<ActionResult> getNotesStudentByPartial(int id, int studentId, int partialId)
        {
            var notes = context.Notes.FirstOrDefault(x => x.PeriodId == id && x.StudentId == studentId && x.PartialId == partialId);
            if (notes == null)
            {
                return NotFound();
            }
            return Ok(notes);
        }

        [HttpGet("period/{id}/students/{studentId}/partials/{partialId}/subjects/{subjectId}")]
        public async Task<ActionResult> getNotesStudentByPartial(int id, int studentId, int partialId, int subjectId)
        {
            var notes = context.Notes.FirstOrDefault(x => x.PeriodId == id && x.StudentId == studentId && x.PartialId == partialId && x.SubjectId == subjectId);
            if (notes == null)
            {
                return NotFound();
            }
            return Ok(notes);
        }
    }
}

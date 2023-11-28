using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School;
using School.DTOs;
using School.Filters;
using School.Models;
using School.Tools;

namespace School.Controllers
{
    [Route("api/subjects")]
    [ApiController]
    public class SubjectController : BaseController<Subject>
    {
        private readonly DatabaseContext _context;

        public SubjectController(DatabaseContext context, IMapper mapper): base(context, context.Subjects, mapper)
        {
            _context = context;
        }

        // GET: api/Subject
        [HttpGet]
        public async Task<ActionResult<PaginatorResponse<Subject>>> GetSubjects([FromQuery] PaginationFilter filter)
        {
            return await GetPaginator(filter);
        }

        // GET: api/Subject/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Subject>> GetSubject(int id)
        {
            return await GetItem(id);
        }

        // PUT: api/Subject/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubject(int id, CreateSubjectDto createSubject)
        {
            return await Update<CreateSubjectDto>(id, createSubject);  
        }

        // POST: api/Subject
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Subject>> PostSubject(CreateSubjectDto createSubject)
        {
            return await Store<CreateSubjectDto>(createSubject, "GetSubject");
        }

        // DELETE: api/Subject/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            return await Destroy(id);
        }

    }
}

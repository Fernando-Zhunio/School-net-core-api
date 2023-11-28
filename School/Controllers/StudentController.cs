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
    [Route("api/students")]
    [ApiController]
    public class StudentController : BaseController<Student>
    {
        private readonly DatabaseContext _context;

        public StudentController(DatabaseContext context, IMapper mapper):base(context, context.Students, mapper)
        {
            _context = context;
        }

        // GET: api/Student
        [HttpGet]
        public async Task<ActionResult<PaginatorResponse<Student>>> GetStudents([FromQuery] PaginationFilter filters)
        {
            return await GetPaginator(filters);
        }

        // GET: api/Student/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            //var student = await _context.Students.FindAsync(id);

            //if (student == null)
            //{
            //    return NotFound();
            //}

            //return student;
            return await GetItem(id);
        }

        // PUT: api/Student/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, CreateStudentDto createStudent)
        {
            //if (id != student.Id)
            //{
            //    return BadRequest();
            //}

            //_context.Entry(student).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!StudentExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}
            return await Update<CreateStudentDto>(id,createStudent);
        }

        // POST: api/Student
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(CreateStudentDto createStudent)
        {
            return await Store<CreateStudentDto>(createStudent, "GetStudent");
        }

        // DELETE: api/Student/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            //var student = await _context.Students.FindAsync(id);
            //if (student == null)
            //{
            //    return NotFound();
            //}

            //_context.Students.Remove(student);
            //await _context.SaveChangesAsync();

            //return NoContent();
            return await Destroy(id);
        }

        //private bool StudentExists(int id)
        //{
        //    return _context.Students.Any(e => e.Id == id);
        //}
    }
}

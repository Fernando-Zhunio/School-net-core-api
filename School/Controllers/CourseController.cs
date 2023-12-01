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
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : BaseController<Course>
    {
        private readonly DatabaseContext _context;

        public CourseController(DatabaseContext context, IMapper mapper): base(context, context.Courses, mapper)
        {
            _context = context;
        }

        // GET: api/Course
        [HttpGet]
        public async Task<ActionResult<PaginatorResponse<Course>>> GetCourses([FromQuery] PaginationFilter filter)
        {
            return await GetPaginator(filter);
        }

        // GET: api/Course/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourse(int id)
        {
            return await GetItem(id);
        }

        // PUT: api/Course/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse(int id, CreateCourseDto course)
        {
            return await Update<CreateCourseDto>(id, course);
        }

        // POST: api/Course
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Course>> PostCourse(CreateCourseDto course)
        {
            return await Store<CreateCourseDto>(course);
        }

        // DELETE: api/Course/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            return await Destroy(id);
        }

    }
}

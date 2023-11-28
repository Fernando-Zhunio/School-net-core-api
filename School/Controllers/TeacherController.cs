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
    [Route("api/teachers")]
    [ApiController]
    public class TeacherController : BaseController<Teacher>
    {
        DatabaseContext context;
        public TeacherController(DatabaseContext dbContext, IMapper mapper): base(dbContext, dbContext.Teachers, mapper) {
            this.context = dbContext;
        }
        // GET: api/<TeacherController>
        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] PaginationFilter filter)
        {
            return await GetPaginator(filter);
        }

        // GET api/<TeacherController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        //POST api/<TeacherController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateTeacherDto createTeacherDto)
        {
            return await Store<CreateTeacherDto>(createTeacherDto);
        }

        // PUT api/<TeacherController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] CreateTeacherDto value)
        {
            return await Update(id, value);
        }

        // DELETE api/<TeacherController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return await Destroy(id);
        }
    }
}

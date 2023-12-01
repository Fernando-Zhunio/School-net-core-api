using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using School.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace School.Controllers
{
    [Route("api/schedules")]
    [ApiController]
    public class ScheduleController : BaseController<Schedule>
    {
        public ScheduleController(DatabaseContext context, IMapper mapper): base(context, context.Schedules, mapper)
        {}
        // GET: api/<ScheduleController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ScheduleController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ScheduleController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ScheduleController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ScheduleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

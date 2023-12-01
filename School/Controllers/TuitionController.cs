using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School;
using School.Models;

namespace School.Controllers
{
    [Route("api/tuitions")]
    [ApiController]
    public class TuitionController : BaseController<Tuition>
    {
        private readonly DatabaseContext context;

        public TuitionController(DatabaseContext context, IMapper mapper): base(context, context.Tuition, mapper)
        {
            this.context = context;
        }

        // GET: api/Tuition
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tuition>>> GetTuition()
        {
            return await context.Tuition.ToListAsync();
        }

        // GET: api/Tuition/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tuition>> GetTuition(int id)
        {
            var tuition = await context.Tuition.FindAsync(id);

            if (tuition == null)
            {
                return NotFound();
            }

            return tuition;
        }

        // PUT: api/Tuition/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTuition(int id, Tuition tuition)
        {
            if (id != tuition.Id)
            {
                return BadRequest();
            }

            context.Entry(tuition).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TuitionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Tuition
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tuition>> PostTuition(Tuition tuition)
        {
            context.Tuition.Add(tuition);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetTuition", new { id = tuition.Id }, tuition);
            //context.Database.BeginTransaction();

            //try
            //{
            //    context.

            //} catch (DbUpdateConcurrencyException)
            //{

            //}

        }

        // DELETE: api/Tuition/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTuition(int id)
        {
            var tuition = await context.Tuition.FindAsync(id);
            if (tuition == null)
            {
                return NotFound();
            }

            context.Tuition.Remove(tuition);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool TuitionExists(int id)
        {
            return context.Tuition.Any(e => e.Id == id);
        }
    }
}

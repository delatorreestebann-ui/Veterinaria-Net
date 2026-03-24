using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Veterinaria.API.Data;
using Veterinaria.Modelos;

namespace Veterinaria.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DueñosController : ControllerBase
    {
        private readonly VeterinariaAPIContext _context;

        public DueñosController(VeterinariaAPIContext context)
        {
            _context = context;
        }

        // GET: api/Dueños
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dueños>>> GetDueños()
        {
            
            var dueños = await _context.Dueños.Include(d => d.Mascotas).ToListAsync();
            return dueños;
        }

        // GET: api/Dueños/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dueños>> GetDueños(int id)
        {
            var dueños = await _context.Dueños.FindAsync(id);

            if (dueños == null)
            {
                return NotFound();
            }

            return dueños;
        }

        // PUT: api/Dueños/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDueños(int id, Dueños dueños)
        {
            if (id != dueños.Id)
            {
                return BadRequest();
            }

            _context.Entry(dueños).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DueñosExists(id))
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

        // POST: api/Dueños
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Dueños>> PostDueños(Dueños dueños)
        {
            _context.Dueños.Add(dueños);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDueños", new { id = dueños.Id }, dueños);
        }

        // DELETE: api/Dueños/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDueños(int id)
        {
            var dueños = await _context.Dueños.FindAsync(id);
            if (dueños == null)
            {
                return NotFound();
            }

            _context.Dueños.Remove(dueños);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DueñosExists(int id)
        {
            return _context.Dueños.Any(e => e.Id == id);
        }
    }
}

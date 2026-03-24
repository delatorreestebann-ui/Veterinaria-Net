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
    public class EspeciesController : ControllerBase
    {
        private readonly VeterinariaAPIContext _context;

        public EspeciesController(VeterinariaAPIContext context)
        {
            _context = context;
        }

        // GET: api/Especies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Especies>>> GetEspecies()
        {
            return await _context.Especies.ToListAsync();
        }

        // GET: api/Especies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Especies>> GetEspecies(int id)
        {
            var especies = await _context.Especies.FindAsync(id);

            if (especies == null)
            {
                return NotFound();
            }

            return especies;
        }

        // PUT: api/Especies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEspecies(int id, Especies especies)
        {
            if (id != especies.Id)
            {
                return BadRequest();
            }

            _context.Entry(especies).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EspeciesExists(id))
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

        // POST: api/Especies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Especies>> PostEspecies(Especies especies)
        {
            _context.Especies.Add(especies);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEspecies", new { id = especies.Id }, especies);
        }

        // DELETE: api/Especies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEspecies(int id)
        {
            var especies = await _context.Especies.FindAsync(id);
            if (especies == null)
            {
                return NotFound();
            }

            _context.Especies.Remove(especies);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EspeciesExists(int id)
        {
            return _context.Especies.Any(e => e.Id == id);
        }
    }
}

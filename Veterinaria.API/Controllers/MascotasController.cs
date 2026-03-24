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
    public class MascotasController : ControllerBase
    {
        private readonly VeterinariaAPIContext _context;

        public MascotasController(VeterinariaAPIContext context)
        {
            _context = context;
        }

        // GET: api/Mascotas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mascotas>>> GetMascotas()
        {
            return await _context.Mascotas.ToListAsync();
        }

        // GET: api/Mascotas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mascotas>> GetMascotas(int id)
        {
            var mascotas = await _context.Mascotas.FindAsync(id);

            if (mascotas == null)
            {
                return NotFound();
            }

            return mascotas;
        }

        // PUT: api/Mascotas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMascotas(int id, Mascotas mascotas)
        {
            if (id != mascotas.Id)
            {
                return BadRequest();
            }

            _context.Entry(mascotas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MascotasExists(id))
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

        // POST: api/Mascotas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Mascotas>> PostMascotas(Mascotas mascotas)
        {
            _context.Mascotas.Add(mascotas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMascotas", new { id = mascotas.Id }, mascotas);
        }

        // DELETE: api/Mascotas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMascotas(int id)
        {
            var mascotas = await _context.Mascotas.FindAsync(id);
            if (mascotas == null)
            {
                return NotFound();
            }

            _context.Mascotas.Remove(mascotas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MascotasExists(int id)
        {
            return _context.Mascotas.Any(e => e.Id == id);
        }
    }
}

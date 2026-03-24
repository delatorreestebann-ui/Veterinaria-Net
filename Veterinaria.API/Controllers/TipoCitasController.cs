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
    public class TipoCitasController : ControllerBase
    {
        private readonly VeterinariaAPIContext _context;

        public TipoCitasController(VeterinariaAPIContext context)
        {
            _context = context;
        }

        // GET: api/TipoCitas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoCitas>>> GetTipoCitas()
        {
            return await _context.TipoCitas.ToListAsync();
        }

        // GET: api/TipoCitas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoCitas>> GetTipoCitas(int id)
        {
            var tipoCitas = await _context.TipoCitas.FindAsync(id);

            if (tipoCitas == null)
            {
                return NotFound();
            }

            return tipoCitas;
        }

        // PUT: api/TipoCitas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoCitas(int id, TipoCitas tipoCitas)
        {
            if (id != tipoCitas.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoCitas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoCitasExists(id))
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

        // POST: api/TipoCitas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoCitas>> PostTipoCitas(TipoCitas tipoCitas)
        {
            _context.TipoCitas.Add(tipoCitas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoCitas", new { id = tipoCitas.Id }, tipoCitas);
        }

        // DELETE: api/TipoCitas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoCitas(int id)
        {
            var tipoCitas = await _context.TipoCitas.FindAsync(id);
            if (tipoCitas == null)
            {
                return NotFound();
            }

            _context.TipoCitas.Remove(tipoCitas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoCitasExists(int id)
        {
            return _context.TipoCitas.Any(e => e.Id == id);
        }
    }
}

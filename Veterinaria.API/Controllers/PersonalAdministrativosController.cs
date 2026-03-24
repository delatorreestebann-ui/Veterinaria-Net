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
    public class PersonalAdministrativosController : ControllerBase
    {
        private readonly VeterinariaAPIContext _context;

        public PersonalAdministrativosController(VeterinariaAPIContext context)
        {
            _context = context;
        }

        // GET: api/PersonalAdministrativos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonalAdministrativos>>> GetPersonalAdministrativos()
        {
            return await _context.PersonalAdministrativos.ToListAsync();
        }

        // GET: api/PersonalAdministrativos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonalAdministrativos>> GetPersonalAdministrativos(int id)
        {
            var personalAdministrativos = await _context.PersonalAdministrativos.FindAsync(id);

            if (personalAdministrativos == null)
            {
                return NotFound();
            }

            return personalAdministrativos;
        }

        // PUT: api/PersonalAdministrativos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonalAdministrativos(int id, PersonalAdministrativos personalAdministrativos)
        {
            if (id != personalAdministrativos.Id)
            {
                return BadRequest();
            }

            _context.Entry(personalAdministrativos).State = EntityState.Modified;

            // ✅ CORRECCIÓN: Se eliminó el BCrypt.HashPassword de aquí.
            // El hash ya viene generado desde el proyecto MVC.

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonalAdministrativosExists(id))
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

        // POST: api/PersonalAdministrativos
        [HttpPost]
        public async Task<ActionResult<PersonalAdministrativos>> PostPersonalAdministrativos(PersonalAdministrativos personalAdministrativos)
        {
            // ✅ CORRECCIÓN: Se eliminó el BCrypt.HashPassword.
            // Si lo dejas aquí, estarías haciendo un "Hash de un Hash", lo que rompe el login.

            _context.PersonalAdministrativos.Add(personalAdministrativos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonalAdministrativos", new { id = personalAdministrativos.Id }, personalAdministrativos);
        }

        // DELETE: api/PersonalAdministrativos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonalAdministrativos(int id)
        {
            var personalAdministrativos = await _context.PersonalAdministrativos.FindAsync(id);
            if (personalAdministrativos == null)
            {
                return NotFound();
            }

            _context.PersonalAdministrativos.Remove(personalAdministrativos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonalAdministrativosExists(int id)
        {
            return _context.PersonalAdministrativos.Any(e => e.Id == id);
        }
    }
}
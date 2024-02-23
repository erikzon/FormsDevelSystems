using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backendForms;
using backendForms.Data;
using Microsoft.AspNetCore.Authorization;

namespace backendForms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EncuestasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EncuestasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Encuestas
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Encuesta>>> GetEncuestas()
        {
            return await _context.Encuestas.ToListAsync();
        }

        // GET: api/Encuestas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Encuesta>> GetEncuesta(Guid id)
        {
            var encuesta = await _context.Encuestas.FindAsync(id);

            if (encuesta == null)
            {
                return NotFound();
            }

            return encuesta;
        }

        // PUT: api/Encuestas/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutEncuesta(Guid id, Encuesta encuesta)
        {
            if (id != encuesta.IdEncuesta)
            {
                return BadRequest();
            }

            _context.Entry(encuesta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EncuestaExists(id))
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

        // POST: api/Encuestas
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Encuesta>> PostEncuesta(Encuesta encuesta)
        {
            _context.Encuestas.Add(encuesta);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEncuesta", new { id = encuesta.IdEncuesta }, encuesta);
        }


        // DELETE: api/Encuestas/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteEncuesta(Guid id)
        {
            var encuesta = await _context.Encuestas.FindAsync(id);
            if (encuesta == null)
            {
                return NotFound();
            }

            _context.Encuestas.Remove(encuesta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EncuestaExists(Guid id)
        {
            return _context.Encuestas.Any(e => e.IdEncuesta == id);
        }
    }
}

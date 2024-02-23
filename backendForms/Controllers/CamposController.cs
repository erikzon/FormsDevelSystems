﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backendForms;
using backendForms.Data;

namespace backendForms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CamposController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CamposController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Campos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Campo>>> GetCampos()
        {
            return await _context.Campos.ToListAsync();
        }

        // GET: api/Campos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Campo>> GetCampo(int id)
        {
            var campo = await _context.Campos.FindAsync(id);

            if (campo == null)
            {
                return NotFound();
            }

            return campo;
        }

        // PUT: api/Campos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCampo(int id, Campo campo)
        {
            if (id != campo.IdCampo)
            {
                return BadRequest();
            }

            _context.Entry(campo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CampoExists(id))
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

        // POST: api/Campos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Campo>> PostCampo(Campo campo)
        {
            _context.Campos.Add(campo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCampo", new { id = campo.IdCampo }, campo);
        }

        // DELETE: api/Campos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCampo(int id)
        {
            var campo = await _context.Campos.FindAsync(id);
            if (campo == null)
            {
                return NotFound();
            }

            _context.Campos.Remove(campo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CampoExists(int id)
        {
            return _context.Campos.Any(e => e.IdCampo == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Inmobiliaria.Models;

namespace Inmobiliaria.Controllers
{
    [Route("api/1.0/[controller]")]
    [ApiController]
    public class TiposViviendaController : ControllerBase
    {
        private readonly InmobiliariaContext _context;

        public TiposViviendaController(InmobiliariaContext context)
        {
            _context = context;
        }

        // GET: api/TiposVivienda
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoVivienda>>> GetTipoVivienda()
        {
            return await _context.TipoVivienda.ToListAsync();
        }

        // GET: api/TiposVivienda/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoVivienda>> GetTipoVivienda(int id)
        {
            var tipoVivienda = await _context.TipoVivienda.FindAsync(id);

            if (tipoVivienda == null)
            {
                return NotFound();
            }

            return tipoVivienda;
        }

        // PUT: api/TiposVivienda/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoVivienda(int id, TipoVivienda tipoVivienda)
        {
            if (id != tipoVivienda.TipoViviendaId)
            {
                return BadRequest();
            }

            _context.Entry(tipoVivienda).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoViviendaExists(id))
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

        // POST: api/TiposVivienda
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoVivienda>> PostTipoVivienda(TipoVivienda tipoVivienda)
        {
            _context.TipoVivienda.Add(tipoVivienda);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoVivienda", new { id = tipoVivienda.TipoViviendaId }, tipoVivienda);
        }

        // DELETE: api/TiposVivienda/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoVivienda(int id)
        {
            var tipoVivienda = await _context.TipoVivienda.FindAsync(id);
            if (tipoVivienda == null)
            {
                return NotFound();
            }

            _context.TipoVivienda.Remove(tipoVivienda);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoViviendaExists(int id)
        {
            return _context.TipoVivienda.Any(e => e.TipoViviendaId == id);
        }
    }
}

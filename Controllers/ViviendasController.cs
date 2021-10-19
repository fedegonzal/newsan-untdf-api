using Inmobiliaria.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inmobiliaria.Controllers
{
    [Route("api/1.0/[controller]")]
    [ApiController]
    public class ViviendasController : ControllerBase
    {
        private readonly InmobiliariaContext _context;

        public ViviendasController(InmobiliariaContext context)
        {
            _context = context;
        }

        // GET: api/Viviendas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vivienda>>> GetViviendas()
        {
            return await _context.Vivienda.ToListAsync();
        }

        // GET: api/Viviendas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vivienda>> GetVivienda(int id)
        {
            var vivienda = await _context.Vivienda.FindAsync(id);

            if (vivienda == null)
            {
                return NotFound();
            }

            return vivienda;
        }

        // PUT: api/Viviendas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVivienda(int id, Vivienda vivienda)
        {
            if (id != vivienda.ViviendaId)
            {
                return BadRequest();
            }

            _context.Entry(vivienda).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ViviendaExists(id))
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

        // POST: api/Viviendas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vivienda>> PostVivienda(Vivienda vivienda)
        {
            _context.Vivienda.Add(vivienda);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVivienda", new { id = vivienda.ViviendaId }, vivienda);
        }

        // DELETE: api/Viviendas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVivienda(int id)
        {
            var vivienda = await _context.Vivienda.FindAsync(id);
            if (vivienda == null)
            {
                return NotFound();
            }

            _context.Vivienda.Remove(vivienda);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ViviendaExists(int id)
        {
            return _context.Vivienda.Any(e => e.ViviendaId == id);
        }
    }
}

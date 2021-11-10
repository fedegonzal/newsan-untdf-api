using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Inmobiliaria.Models;
using System.Collections.ObjectModel;

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
        public async Task<ActionResult<IEnumerable<Vivienda>>> GetVivienda()
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

            // La variable vivienda tendrá la información que recibimos por PUT
            // La variable viv tendrá la info original de la vivienda con el id recibido

            var viv = await _context.Vivienda.FindAsync(id);

            // Borraremos los propietarios de la vivienda para reemplazarlos con los recibidos
            
            if (viv.Propietarios != null)
            {
                viv.Propietarios.Clear();
            }

            await _context.SaveChangesAsync();

            // Esto es importante porque tenemos que avisarle a EF
            // que aquí termina una transacción y comienza otra
            _context.ChangeTracker.Clear();


            // Agregamos a la info de la vivienda los nuevos propietarios
            if (vivienda.PropietariosList != null)
            {
                foreach (var propId in vivienda.PropietariosList)
                {
                    var propietario = await _context.Propietario.FindAsync(propId);
                    if (propietario != null)
                    {
                        vivienda.Propietarios.Add(propietario);
                    }
                }
            }

            // Avisamos que hemos modificado la vivienda para que EF tome los cambios al guardar
            _context.Entry(vivienda).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            // Si llegamos aquí es porque todo salió bien
            // devolvemos OK (http 200) y los datos de la vivienda
            return Ok(vivienda);
        }

        // POST: api/Viviendas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vivienda>> PostVivienda(Vivienda vivienda)
        {
            // A cada uno de los propietarios recibidos lo agregamos a la vivienda
            foreach (var item in vivienda.PropietariosList)
            {
                Propietario p = await _context.Propietario.FindAsync(item);
                vivienda.Propietarios.Add(p);
            }

            // Agregamos la vivienda con toda su info a la base de datos
            _context.Vivienda.Add(vivienda);
            await _context.SaveChangesAsync();

            // Devolvemos CREATED con la vivienda generada
            return CreatedAtAction("GetVivienda", new { id = vivienda.ViviendaId }, vivienda);
        }

        // DELETE: api/Viviendas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVivienda(int id)
        {
            // buscamos la vivienda que tiene el ID recibido
            var vivienda = await _context.Vivienda.FindAsync(id);

            if (vivienda == null)
            {
                return NotFound();
            }

            // Borramos la vivienda y todas sus relaciones en cascada
            _context.Vivienda.Remove(vivienda);
            await _context.SaveChangesAsync();

            // Devolvemos NO CONTENT porque ya no existe
            return NoContent();
        }

        private bool ViviendaExists(int id)
        {
            return _context.Vivienda.Any(e => e.ViviendaId == id);
        }
    }
}

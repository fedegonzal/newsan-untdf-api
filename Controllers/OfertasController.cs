﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Inmobiliaria.Models;
using System.Net.Http;
using System.Net;

namespace Inmobiliaria.Controllers
{
    [Route("api/1.0/[controller]")]
    [ApiController]
    public class OfertasController : ControllerBase
    {
        private readonly InmobiliariaContext _context;

        public OfertasController(InmobiliariaContext context)
        {
            _context = context;
        }

        // GET: api/Ofertas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Oferta>>> GetOferta()
        {
            return await _context.Oferta.ToListAsync();
        }


        // GET: api/ofertas/buscar
        [HttpGet("buscar")]
        public dynamic Buscar(string operacion, float precioMin = 0, float precioMax = 99999999999999999)
        {
            return _context.Oferta
                .Where(item => 
                    item.Precio >= precioMin && 
                    item.Precio <= precioMax && 
                    item.Operacion.Nombre == operacion
                )
                .Select(item => new { 
                    item.Precio, 
                    Operacion = item.Operacion.Nombre,
                    Domicilio = item.Vivienda.DomicilioCalle + " " + item.Vivienda.DomicilioNumero,
                    item.Vivienda.GasNatural,
                    TipoVivienda = item.Vivienda.TipoVivienda.Nombre
                })
                .ToList();

        }


        // GET: api/Ofertas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Oferta>> GetOferta(int id)
        {
            var oferta = await _context.Oferta.FindAsync(id);

            if (oferta == null)
            {
                return NotFound();
            }

            return oferta;
        }

        // PUT: api/Ofertas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOferta(int id, Oferta oferta)
        {
            if (id != oferta.OfertaId)
            {
                return BadRequest();
            }

            _context.Entry(oferta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfertaExists(id))
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

        // POST: api/Ofertas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Oferta>> PostOferta(Oferta oferta)
        {
            _context.Oferta.Add(oferta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOferta", new { id = oferta.OfertaId }, oferta);
        }

        // DELETE: api/Ofertas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOferta(int id)
        {
            var oferta = await _context.Oferta.FindAsync(id);
            if (oferta == null)
            {
                return NotFound();
            }

            _context.Oferta.Remove(oferta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OfertaExists(int id)
        {
            return _context.Oferta.Any(e => e.OfertaId == id);
        }
    }
}

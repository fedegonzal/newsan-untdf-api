using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

using Inmobiliaria.Models;
using Inmobiliaria.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Inmobiliaria.Controllers
{
    [Route("api/1.0/[controller]")]
    [ApiController]
    public class ViviendasOldController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Vivienda>> GetAll()
        {
            return ViviendaService.GetAll();
        }


        [HttpGet("{id}")]
        public ActionResult<Vivienda> Get(int id)
        {
            var vivienda = ViviendaService.Get(id);

            if (vivienda == null)
                return NotFound();

            return vivienda;
        }


        // POST api/<InmueblesController>
        [HttpPost]
        //public void Post([FromBody] string value)
        public ActionResult<Vivienda> Create(Vivienda vivienda)
        {
            // This code will save the inmueble and return a result
            vivienda = ViviendaService.Add(new Vivienda { DomicilioCalle = vivienda.DomicilioCalle } );
            return vivienda;
        }

        // PUT api/<InmueblesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<InmueblesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

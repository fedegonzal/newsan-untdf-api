using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inmobiliaria.Models
{
    public class Oferta
    {
        public int Id { get; set; }
        public float Precio { get; set; }

//        public int ViviendaId { get; set; }
        public Vivienda Vivienda { get; set; }

//        public int OperacionId { get; set; }
        public Operacion Operacion { get; set; }
    }
}

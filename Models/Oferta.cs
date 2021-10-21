using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inmobiliaria.Models
{
    public class Oferta
    {
        public int OfertaId { get; set; }
        public float Precio { get; set; }

        public int ViviendaId { get; set;  }
        public virtual Vivienda Vivienda { get; set; }

        public int OperacionId { get; set; }
        public virtual Operacion Operacion { get; set; }
    }
}

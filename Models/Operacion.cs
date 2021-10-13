using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inmobiliaria.Models
{
    public class Operacion
    {
        public int OperacionId { get; set; }
        public string Nombre { get; set; }
        public float Tolerancia { get; set; }

//        public virtual ICollection<Oferta> Ofertas { get; set; }
    }
}

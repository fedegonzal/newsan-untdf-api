using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inmobiliaria.Models
{
    public class Propietario
    {
        public int PropietarioId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public long DNI { get; set; }

        public virtual ICollection<Vivienda> Viviendas { get; set; }
    }
}

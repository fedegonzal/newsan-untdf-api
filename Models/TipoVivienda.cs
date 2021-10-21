using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inmobiliaria.Models
{
    public class TipoVivienda
    {
        public int TipoViviendaId { get; set; }

        public string Nombre { set; get; }

        public virtual ICollection<Vivienda> Viviendas { get; set; } = new List<Vivienda>();
    }
}

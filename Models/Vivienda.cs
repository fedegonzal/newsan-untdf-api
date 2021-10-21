using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Inmobiliaria.Models
{
    public class Vivienda
    {
        public int ViviendaId { get; set; }
        public string DescripcionCorta { get; set; }
        public string DomicilioCalle { get; set; }
        public string DomicilioNumero { get; set; }
        public string DescripcionLarga { get; set; }
        public bool GasNatural { get; set; }
        public float Latitud { get; set; }
        public float Longitud { get; set; }

        public int TipoViviendaId { get; set; }

        public virtual TipoVivienda TipoVivienda { get; set; }

//        public virtual ICollection<Oferta> Ofertas { get; set; }

        public virtual ICollection<Propietario> Propietarios { get; set; }

        
    }
}

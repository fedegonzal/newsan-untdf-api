using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inmobiliaria.Models
{
    public class Vivienda
    {
        public int Id { get; set; }
        public string DescripcionCorta { get; set; }
        public string DomicilioCalle { get; set; }
        public string DomicilioNumero { get; set; }
        public string DescripcionLarga { get; set; }
        public bool GasNatural { get; set; }
        public float Latitud { get; set; }
        public float Longitud { get; set; }

        //public ICollection<Oferta> Ofertas { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inmobiliaria.Models
{
    public class Operacion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public float Tolerancia { get; set; }
    }
}

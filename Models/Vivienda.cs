using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Inmobiliaria.Models
{
    public class Vivienda
    {
        public Vivienda()
        {
            Propietarios = new List<Propietario>();
        }

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

        public virtual ICollection<Oferta> Ofertas { get; set; }

        // Esta anotación se usa para decirle a EF que
        // no cree un campo real en la base de datos para este campo
        // El campo PropietariosList nos servirá para recibir una lista
        // de IDs de propietarios y con ello vincularlos a la vivienda (en POST y PUT)
        [NotMapped]
        public List<int> PropietariosList { get; set; }
        public virtual ICollection<Propietario> Propietarios { get; set; }
    }

}

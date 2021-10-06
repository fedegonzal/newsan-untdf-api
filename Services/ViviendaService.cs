using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inmobiliaria.Models;

namespace Inmobiliaria.Services
{
    public static class ViviendaService
    {
        static List<Vivienda> Viviendas { get; set; }

        static ViviendaService()
        {
            leerViviendas();
        }

        private static void leerViviendas()
        {
            Viviendas = new List<Vivienda>();
            int lineNumber = 1;

            foreach (string linea in System.IO.File.ReadLines(@"viviendas.csv"))
            {
                Console.WriteLine(linea);
                Viviendas.Add( new Vivienda { Id = lineNumber, DomicilioCalle = linea } );
                lineNumber++;
            }

        }

        public static List<Vivienda> GetAll()
        {
            leerViviendas();

            Console.WriteLine("*****************");
            Console.WriteLine(Viviendas);
            return Viviendas;
        }

        public static Vivienda Get(int id) => Viviendas.FirstOrDefault(item => item.Id == id);

        public static List<Vivienda> TraerPorDomicilio(string textoABuscar) => Viviendas.FindAll(item => item.DomicilioCalle.Contains(textoABuscar));

        public static Vivienda Add(Vivienda inmueble)
        {
            System.IO.File.AppendAllText("viviendas.csv", inmueble.DomicilioCalle + Environment.NewLine);
            inmueble.Id = Viviendas.Count + 1;
            Viviendas.Add(inmueble);
            return inmueble;
        }
    }
}

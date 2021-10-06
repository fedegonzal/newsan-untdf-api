using Microsoft.EntityFrameworkCore;
using Inmobiliaria.Models;

namespace Inmobiliaria.Models
{
    public class InmobiliariaContext : DbContext
    {
        public InmobiliariaContext(DbContextOptions<InmobiliariaContext> options) : base(options)
        {
        }

        public DbSet<Vivienda> Viviendas { get; set; }

        public DbSet<Inmobiliaria.Models.Operacion> Operacion { get; set; }
    }
}

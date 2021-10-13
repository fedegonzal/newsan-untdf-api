using Microsoft.EntityFrameworkCore;
using Inmobiliaria.Models;

namespace Inmobiliaria.Models
{
    public class InmobiliariaContext : DbContext
    {
        public InmobiliariaContext(DbContextOptions<InmobiliariaContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Inmobiliaria.Models.Vivienda> Vivienda { get; set; }
        public DbSet<Inmobiliaria.Models.Operacion> Operacion { get; set; }
        public DbSet<Inmobiliaria.Models.Oferta> Oferta { get; set; }
    }
}

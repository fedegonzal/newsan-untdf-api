using Microsoft.EntityFrameworkCore;
using Inmobiliaria.Models;

namespace Inmobiliaria.Models
{
    public class InmobiliariaContext : DbContext
    {
        public InmobiliariaContext(DbContextOptions<InmobiliariaContext> options) : base(options)
        {
            //Configuration.LazyLoadingEnabled = true;
            //Configuration.ProxyCreationEnabled = true;            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
/*            modelBuilder.Entity<TipoVivienda>()
                .HasMany(item => item.Viviendas)
                .WithOne();

            modelBuilder.Entity<Vivienda>()
                .HasOne(item => item.TipoVivienda)
                .WithMany(item => item.Viviendas);*/
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        public DbSet<Inmobiliaria.Models.Vivienda> Vivienda { get; set; }
        public DbSet<Inmobiliaria.Models.Operacion> Operacion { get; set; }
        public DbSet<Inmobiliaria.Models.Oferta> Oferta { get; set; }
        public DbSet<Inmobiliaria.Models.TipoVivienda> TipoVivienda { get; set; }
        public DbSet<Inmobiliaria.Models.Propietario> Propietario { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using MiPrimeraApiRest.Modelos;

namespace MiPrimeraApiRest.Datos
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Villa> Villas { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Villa>().HasData(
                  new Villa() { 
                   Id = 1,
                   Nombre = "Villa 1",
                   Detalle = "Villa 1",
                   Tarifa = 100,
                   Ocupantes = 4,
                   MetrosCuadrados = 100,
                   ImagenUrl = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.villas.com%2Fespana%",
                   Amenidades = "Amenidades 1",
                   FechaCreacion = System.DateTime.Now,
                   FechaModificacion = System.DateTime.Now

                  },
                   new Villa()
                   {
                       Id = 2,
                       Nombre = "Villa 2",
                       Detalle = "Villa 2",
                       Tarifa = 100,
                       Ocupantes = 4,
                       MetrosCuadrados = 100,
                       ImagenUrl = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.villas.com%2Fespana%",
                       Amenidades = "Amenidades 2",
                       FechaCreacion = System.DateTime.Now,
                       FechaModificacion = System.DateTime.Now

                   }
                );
        }
    }
}

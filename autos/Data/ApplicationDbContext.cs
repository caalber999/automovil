using autos.Models;
using Microsoft.EntityFrameworkCore;

namespace autos.Data
{
    // Clase que define el contexto de la base de datos, hereda de DbContext
    public class ApplicationDbContext : DbContext
    {
        // Propiedad que representa la tabla de 'MarcasAutos' en la base de datos
        public DbSet<MarcaAuto> MarcasAutos { get; set; }

        // Constructor que inyecta las opciones de configuración del contexto de la base de datos
        // Utiliza las opciones pasadas desde la configuración de la aplicación, como el tipo de base de datos y la cadena de conexión
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Método opcional para configurar opciones adicionales de la base de datos, si es necesario.
        // Aquí está vacío porque las configuraciones se realizan a través de las opciones inyectadas
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // No hay configuraciones adicionales, ya que normalmente se configuran externamente (e.g., en `appsettings.json`)
        }

        // Método para configurar el modelo de datos, define las relaciones y datos iniciales (seeding)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seeding de la tabla MarcasAutos con datos iniciales.
            // Estos datos se insertan automáticamente cuando se crea la base de datos o se ejecutan migraciones
            modelBuilder.Entity<MarcaAuto>().HasData(
                new MarcaAuto { Id = 1, Nombre = "Toyota" }, // Inserta la marca Toyota con ID 1
                new MarcaAuto { Id = 2, Nombre = "Honda" },  // Inserta la marca Honda con ID 2
                new MarcaAuto { Id = 3, Nombre = "Ford" }    // Inserta la marca Ford con ID 3
            );
        }
    }
}

using autos.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace autos.Extensions
{
    // Clase estática que extiende las funcionalidades de IHost para aplicar migraciones de base de datos automáticamente
    public static class MigrationExtensions
    {
        // Método de extensión para IHost que aplica las migraciones pendientes en la base de datos
        public static IHost ApplyMigrations(this IHost host)
        {
            // Crea un scope de servicios para obtener el contexto de la base de datos (ApplicationDbContext)
            using (var scope = host.Services.CreateScope())
            {
                // Obtiene una instancia del contexto de la base de datos a través del servicio inyectado
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                try
                {
                    // Aplica las migraciones pendientes en la base de datos
                    dbContext.Database.Migrate();
                }
                catch (Exception ex)
                {
                    // Captura cualquier excepción durante el proceso de migración y la imprime en la consola
                    Console.WriteLine("Error applying migrations: " + ex.Message);
                    // Vuelve a lanzar la excepción para asegurar que el error no pase desapercibido
                    throw;
                }
            }

            // Devuelve el host para permitir encadenar otros métodos si es necesario
            return host;
        }
    }
}

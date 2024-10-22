using autos.Data;
using autos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// Definición del namespace para el controlador de Marcas de Autos
namespace autos.Controllers
{
    // Establece el prefijo de la ruta para las solicitudes HTTP que se manejarán en este controlador
    // [Route("api/[controller]")] toma el nombre del controlador (MarcasAutos) y lo convierte en la ruta "api/marcasautos"
    [Route("api/[controller]")]
    [ApiController] // Indica que este controlador maneja solicitudes API y automáticamente enlaza las respuestas al formato JSON o XML
    public class MarcasAutosController : ControllerBase
    {
        // Inyección de dependencias para acceder a la base de datos a través de ApplicationDbContext
        private readonly ApplicationDbContext _context;

        // Constructor del controlador que inyecta el contexto de la base de datos
        public MarcasAutosController(ApplicationDbContext context)
        {
            _context = context; // El contexto se asigna a la variable privada _context para ser utilizado en los métodos
        }

        // Método GET que obtiene una lista de todas las marcas de autos desde la base de datos
        [HttpGet] // Define que este método responde a solicitudes HTTP GET
        public async Task<ActionResult<IEnumerable<MarcaAuto>>> GetMarcasAutos()
        {
            try
            {
                // Obtiene la lista de marcas de autos de la base de datos de manera asíncrona
                var marcasAutos = await _context.MarcasAutos.ToListAsync();

                // Devuelve la lista con el código de estado HTTP 200 (OK)
                return Ok(marcasAutos);
            }
            catch (Exception ex)
            {
                // Manejo de errores: en caso de una excepción, devuelve un código 500 (Internal Server Error)
                // y un mensaje detallando el error
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }
}

using System.ComponentModel.DataAnnotations;

namespace autos.Models
{
    public class MarcaAuto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public required string Nombre { get; set; }
    }
}

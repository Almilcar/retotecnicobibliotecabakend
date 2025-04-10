using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class Libro
    {
        [Key]  // Indica que esta propiedad es la clave primaria
        [Column("IdLibro")]  // Especifica el nombre de la columna en la base de datos
        public int Id { get; set; }

        [Required]
        [StringLength(200)]  // Se establece un límite de caracteres para el título
        public string Titulo { get; set; }

        [StringLength(100)]
        public string Categoria { get; set; }

        [StringLength(100)]
        public string Editorial { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal PrecioVenta { get; set; }

        [StringLength(50)]
        public string Estado { get; set; }
    }
}

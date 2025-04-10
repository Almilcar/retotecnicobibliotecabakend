using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class CopiaLibro
    {
        [Key]   
        [Column("IdCopia")]   
        public int IdCopia { get; set; }

        [Required]
        [StringLength(100)]  
        public string CodigoBarras { get; set; }

        public int IdLibro { get; set; }   

        [StringLength(100)]
        public string UbicacionEstante { get; set; }

        [StringLength(50)]
        public string EstadoCopia { get; set; }

        [ForeignKey("IdLibro")]
        public Libro Libro { get; set; }   
    }
}

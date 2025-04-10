using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication.Models
{
    [Table("DetallePrestamo")]
    public class DetallePrestamo
    {
        [Key]
        [Column("IdDetalle")]
        public int IdDetalle { get; set; }
        [ForeignKey("Prestamo")]
        [Column("IdPrestamo")]
        public int IdPrestamo { get; set; }

        [ForeignKey("CopiaLibro")]   
        [Column("IdCopia")]
        public int IdCopia { get; set; }
        public DateTime FechaEntrega { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        public decimal? Penalidad { get; set; }

        public Prestamo Prestamo { get; set; }
        public CopiaLibro CopiaLibro { get; set; }
    }
}

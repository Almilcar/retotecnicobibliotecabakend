using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication.Models
{
    [Table("Prestamo")]
    public class Prestamo
    {
        [Key]
        [Column("IdPrestamo")]  
        public int IdPrestamo { get; set; }

        [ForeignKey("Cliente")]  
        [Column("IdCliente")]  
        public int IdCliente { get; set; }
        public DateTime FechaSolicitud { get; set; } = DateTime.Now;
        public string Estado { get; set; } = "Pendiente";
        public string MedioEntrega { get; set; }

        public ICollection<DetallePrestamo> Detalles { get; set; }
        public Cliente Cliente { get; set; }
    }

}

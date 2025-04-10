using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class Cliente
    {
        [Key]   
        [Column("IdCliente")]   
        public int IdCliente { get; set; }

        [Required]
        [StringLength(150)]   
        public string? NombreCompleto { get; set; }

        [StringLength(20)]
        public string? Documento { get; set; }

        [StringLength(20)]
        public string? Telefono { get; set; }

        [StringLength(100)]
        public string? Email { get; set; }

        [StringLength(200)]
        public string? Direccion { get; set; }

        [StringLength(10)]
        public string? Ubigeo { get; set; }

        public bool? EnListaNegra { get; set; }

        public string? Departamento { get; set; }
        public string?  Provincia{ get; set; }
        public string?  Distrito{ get; set; }

        public string? TipoDocumento { get; set; }
    }
}

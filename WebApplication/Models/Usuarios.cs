using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class Usuarios
    {
        [Key]
        [Column("IdUsuario")]
        public int IdUsuario { get; set; }
        public string Usuario { get; set; }
        public string ContraseniaHash { get; set; }
        public string Rol { get; set; }
        public bool Activo { get; set; }
    }
}

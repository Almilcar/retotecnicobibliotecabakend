namespace WebApplication.DTOs
{
    public class PrestamoRequestDTO
    {
        public int IdCliente { get; set; }
        public string MedioEntrega { get; set; }
        public List<DetallePrestamoDTO> Libros { get; set; }
    }
}

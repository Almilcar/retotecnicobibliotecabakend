using WebApplication.DTOs;

namespace WebApplication.Services
{
    public interface IPrestamoService
    {
        Task<bool> RegistrarPrestamoAsync(PrestamoDTO request);

        Task<List<PrestamoDTO>> ObtenerPrestamosAsync();
    }
}

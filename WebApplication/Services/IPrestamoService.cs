using WebApplication.DTOs;

namespace WebApplication.Services
{
    public interface IPrestamoService
    {
        Task<bool> RegistrarPrestamoAsync(PrestamoRequestDTO request);
    }
}

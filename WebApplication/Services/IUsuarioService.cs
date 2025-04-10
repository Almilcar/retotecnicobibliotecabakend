using WebApplication.Models;

namespace WebApplication.Services
{
    public interface IUsuarioService
    {
        Task<IEnumerable<Usuarios>> GetUsuariosAsync();
        Task<Usuarios> GetUsuarioByIdAsync(int id);
        Task<Usuarios> CreateUsuarioAsync(Usuarios usuario);
        Task<bool> UpdateUsuarioAsync(int id, Usuarios usuario);
        Task<bool> DeleteUsuarioAsync(int id);
    }
}

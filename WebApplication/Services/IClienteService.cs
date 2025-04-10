using WebApplication.Models;

namespace WebApplication.Services
{
    public interface IClienteService
    {
        Task<IEnumerable<Cliente>> GetAllClientsAsync();
        Task<Cliente> GetClientByIdAsync(int id);
        Task CreateClientAsync(Cliente cliente);
        Task UpdateClientAsync(Cliente cliente);
        Task DeleteClientAsync(int id);
    }
}

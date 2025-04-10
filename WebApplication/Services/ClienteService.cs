using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApplication.Data;
using WebApplication.Models;

namespace WebApplication.Services
{
    public class ClienteService : IClienteService
    {
        private readonly ApplicationDbContext _context;

        public ClienteService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> GetAllClientsAsync()
        {
            return await _context.Cliente.ToListAsync();
        }

        public async Task<Cliente> GetClientByIdAsync(int id)
        {
            return await _context.Cliente.FirstOrDefaultAsync(c => c.IdCliente == id);
        }

        async Task IClienteService.CreateClientAsync(Cliente cliente)
        {
            try
            {
                _context.Cliente.Add(cliente);
                await _context.SaveChangesAsync();
               

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar en la base de datos: {ex.Message}");
              
            }
        }




        public async Task UpdateClientAsync(Cliente cliente)
        {
            _context.Cliente.Update(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteClientAsync(int id)
        {
            var cliente = await _context.Cliente.FirstOrDefaultAsync(c => c.IdCliente == id);
            if (cliente != null)
            {
                _context.Cliente.Remove(cliente);
                await _context.SaveChangesAsync();
            }
        }
 
    }
}
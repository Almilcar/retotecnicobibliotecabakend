using Microsoft.EntityFrameworkCore;
using WebApplication.Data;
using WebApplication.Models;

namespace WebApplication.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly ApplicationDbContext _context;

        public UsuarioService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuarios>> GetUsuariosAsync()
        {
            return await _context.Usuario.ToListAsync();
        }

        public async Task<Usuarios> GetUsuarioByIdAsync(int id)
        {
            return await _context.Usuario.FindAsync(id);
        }

        public async Task<Usuarios> CreateUsuarioAsync(Usuarios usuario)
        {
            usuario.ContraseniaHash = BCrypt.Net.BCrypt.HashPassword(usuario.ContraseniaHash); 
            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<bool> UpdateUsuarioAsync(int id, Usuarios usuario)
        {
            if (id != usuario.IdUsuario)
            {
                return false;
            }

            _context.Entry(usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteUsuarioAsync(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return false;
            }

            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
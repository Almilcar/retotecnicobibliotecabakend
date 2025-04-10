using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Globalization;
using WebApplication.ConexionBD;
using WebApplication.Data;
using WebApplication.DTOs;
using WebApplication.Models;

namespace WebApplication.Services
{
    public class PrestamoService : IPrestamoService
    {
        private readonly ApplicationDbContext _context;

        public PrestamoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> RegistrarPrestamoAsync(PrestamoRequestDTO request)
        {
            try
            {
                var clienteExistente = await _context.Cliente
                    .AnyAsync(c => c.IdCliente == request.IdCliente);

                if (!clienteExistente)
                    throw new Exception("El cliente no existe.");

                foreach (var libro in request.Libros)
                {
                    var copiaExistente = await _context.CopiaLibro
                        .AnyAsync(c => c.IdCopia == libro.IdCopia);

                    if (!copiaExistente)
                        throw new Exception($"La copia de libro con ID {libro.IdCopia} no existe o registre más de una copia.");

                    var enUso = await _context.Detalles
                        .AnyAsync(x => x.IdCopia == libro.IdCopia && x.FechaDevolucion == null);

                    if (enUso)
                        throw new Exception($"El libro con copia ID {libro.IdCopia} no está disponible.");
                }

                // Crear el objeto de préstamo
                var prestamo = new Prestamo
                {
                    IdCliente = request.IdCliente,
                    MedioEntrega = request.MedioEntrega,
                    Detalles = request.Libros.Select(libro => new DetallePrestamo
                    {
                        IdCopia = libro.IdCopia,
                        FechaEntrega = libro.FechaEntrega
                    }).ToList()
                };

                _context.Prestamo.Add(prestamo);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                // Loguear el error
                Console.WriteLine($"Error al guardar en la base de datos: {ex.Message}");
                throw;
            }
        }
    }
}

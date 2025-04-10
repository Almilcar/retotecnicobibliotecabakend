 
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApplication.Models;

namespace WebApplication.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

  
        public DbSet<Prestamo> Prestamo { get; set; }
        public DbSet<DetallePrestamo> Detalles { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<CopiaLibro> CopiaLibro { get; set; }
        public DbSet<Usuarios> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Prestamo>()
                .HasKey(p => p.IdPrestamo);

            modelBuilder.Entity<Prestamo>()
                .HasOne(p => p.Cliente)
                .WithMany()  
                .HasForeignKey(p => p.IdCliente);

            modelBuilder.Entity<DetallePrestamo>()
                .HasKey(d => d.IdDetalle);

            modelBuilder.Entity<DetallePrestamo>()
                .HasOne(d => d.Prestamo)
                .WithMany(p => p.Detalles)  
                .HasForeignKey(d => d.IdPrestamo);

            modelBuilder.Entity<DetallePrestamo>()
               .HasOne(d => d.CopiaLibro)
               .WithMany()   
               .HasForeignKey(d => d.IdCopia);
        }
    }

}

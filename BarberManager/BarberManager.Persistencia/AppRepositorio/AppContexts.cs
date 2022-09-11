using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BarberManager.Dominio;
namespace BarberManager.Persistencia
{
    public class AppContexts : DbContext
    {
        public DbSet<Barbero> Barberos { get; set; }
        public DbSet<DetalleServicio> DetalleServicios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Servicio> Sevicios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Venta> Ventas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
               .UseSqlServer("Server=tcp:s-east.database.windows.net,1433;Initial Catalog=barber_manager;Persist Security Info=False;User ID=presume5479;Password=N!ftQ^5gbxxBwV2yw#&Fk2H;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }
    }
}
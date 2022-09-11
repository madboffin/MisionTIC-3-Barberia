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
<<<<<<< HEAD
               //.UseSqlServer("Server=20.168.13.51; Database=barberia; user=sa; password=P3g4sus.2022*;");
               .UseSqlServer("Server=LAPTOP-5I9PKCH7; Database=HospiEnCasa; Integrated Security=True;") ;
=======
               .UseSqlServer("Server=tcp:s-east.database.windows.net,1433;Initial Catalog=barber_manager;Persist Security Info=False;User ID=presume5479;Password=N!ftQ^5gbxxBwV2yw#&Fk2H;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
>>>>>>> d470117a4fc13ca63cb5494c64ca8a1e979c53b0
            }
        }
    }
}
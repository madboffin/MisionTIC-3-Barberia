using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BarberManager.Dominio;

namespace BarberManager.Persistencia.AppRepositorio
{
    public class AppContexts : DbContext
    {
        public DbSet<Barbero> Barbero { get; set; }
        public DbSet<DetalleServicio> DetalleServicio { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Servicio> Sevicio { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Venta> Venta { get; set; }
       
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
               .UseSqlServer("Server=20.168.13.51; Database=barberia; user=sa; password=P3g4sus.2022*;");
               // .UseSqlServer("Server=LAPTOP-5I9PKCH7; Database=HospiEnCasa; Integrated Security=True;") ;
            }
        }


    }
}
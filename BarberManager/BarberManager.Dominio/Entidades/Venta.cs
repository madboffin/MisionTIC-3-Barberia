using System;
namespace BarberManager.Dominio
{
    public class Venta
    {
        public int Id { get; set; }
        public int Valor { get; set; }
        public DateTime Fecha { get; set; }
        public Barbero Barbero { get; set; }
        public Usuario Usuario { get; set; }
        public DetalleServicio DetalleServicio { get; set; }
    }
}
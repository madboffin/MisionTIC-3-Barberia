using System;
namespace BarberManager.Dominio
{
    public class DetalleServicio
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public int Precio { get; set; }
        public Servicio Servicio { get; set; }
    }
}
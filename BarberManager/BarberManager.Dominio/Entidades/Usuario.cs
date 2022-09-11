using System;
namespace BarberManager.Dominio
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Contrasena { get; set; }
        public Rol Rol { get; set; }
        public int Estado { get; set; }
        public string Correo { get; set; }
    }
}
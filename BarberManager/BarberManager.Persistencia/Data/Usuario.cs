using System;
using System.Collections.Generic;

#nullable disable

namespace BarberManager.Persistencia.Data
{
    public partial class Usuario
    {
        public Usuario()
        {
            Barberos = new HashSet<Barbero>();
            Venta = new HashSet<Venta>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Contrasena { get; set; }
        public int IdRol { get; set; }
        public int Estado { get; set; }
        public string Correo { get; set; }

        public virtual Rol IdRolNavigation { get; set; }
        public virtual ICollection<Barbero> Barberos { get; set; }
        public virtual ICollection<Venta> Venta { get; set; }
    }
}

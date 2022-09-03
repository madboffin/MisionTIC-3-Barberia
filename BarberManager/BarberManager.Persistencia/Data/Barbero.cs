using System;
using System.Collections.Generic;

#nullable disable

namespace BarberManager.Persistencia.Data
{
    public partial class Barbero
    {
        public Barbero()
        {
            Venta = new HashSet<Venta>();
        }

        public int Id { get; set; }
        public string TipoDocumento { get; set; }
        public string Documento { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public int IdUsuario { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Venta> Venta { get; set; }
    }
}

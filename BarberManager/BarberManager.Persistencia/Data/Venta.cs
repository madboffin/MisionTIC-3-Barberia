using System;
using System.Collections.Generic;

#nullable disable

namespace BarberManager.Persistencia.Data
{
    public partial class Venta
    {
        public Venta()
        {
            DetalleServicios = new HashSet<DetalleServicio>();
        }

        public int Id { get; set; }
        public int Valor { get; set; }
        public DateTime Fecha { get; set; }
        public int IdBarberos { get; set; }
        public int IdUsuarios { get; set; }

        public virtual Barbero IdBarberosNavigation { get; set; }
        public virtual Usuario IdUsuariosNavigation { get; set; }
        public virtual ICollection<DetalleServicio> DetalleServicios { get; set; }
    }
}

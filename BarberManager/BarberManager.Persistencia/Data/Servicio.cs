using System;
using System.Collections.Generic;

#nullable disable

namespace BarberManager.Persistencia.Data
{
    public partial class Servicio
    {
        public Servicio()
        {
            DetalleServicios = new HashSet<DetalleServicio>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Precio { get; set; }

        public virtual ICollection<DetalleServicio> DetalleServicios { get; set; }
    }
}

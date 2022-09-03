using System;
using System.Collections.Generic;

#nullable disable

namespace BarberManager.Persistencia.Data
{
    public partial class DetalleServicio
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public int Precio { get; set; }
        public int IdServicios { get; set; }
        public int IdVentas { get; set; }

        public virtual Servicio IdServiciosNavigation { get; set; }
        public virtual Venta IdVentasNavigation { get; set; }
    }
}

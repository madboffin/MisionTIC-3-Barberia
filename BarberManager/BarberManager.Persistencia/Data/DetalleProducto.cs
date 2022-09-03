using System;
using System.Collections.Generic;

#nullable disable

namespace BarberManager.Persistencia.Data
{
    public partial class DetalleProducto
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public int Precio { get; set; }
        public int IdProductos { get; set; }

        public virtual Producto IdProductosNavigation { get; set; }
    }
}

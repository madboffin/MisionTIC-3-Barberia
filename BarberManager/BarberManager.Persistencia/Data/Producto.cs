using System;
using System.Collections.Generic;

#nullable disable

namespace BarberManager.Persistencia.Data
{
    public partial class Producto
    {
        public Producto()
        {
            DetalleProductos = new HashSet<DetalleProducto>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Precio { get; set; }
        public int Disponible { get; set; }

        public virtual ICollection<DetalleProducto> DetalleProductos { get; set; }
    }
}

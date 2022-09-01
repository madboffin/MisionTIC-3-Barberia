using System;
using System.Collections.Generic;
namespace App.Dominio{    
    /// <summary>Class <c>Venta</c>
    /// Modelo una venta en la barberia
    /// </summary>   
    public class Venta{
        public DateTime Fecha {get;set;};
        public Barbero Barbero {get;set;};
        public Usuario Usuario {get;set;};
        public List<Servicio> Servicios {get;set;};
        public List<Producto> Productos {get;set;};
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BarberManager.Dominio;

namespace BarberManager.Persistencia.AppRepositorio
{
    public class RepositorioVenta :ICRUD<Venta>
    {
        private readonly AppContexts appContexts;
        public RepositorioVenta(AppContexts appContexts)
        {
            this.appContexts = appContexts;
        }

        public Venta Actualizar(Venta obj)
        {
            var ventaEncontrada = Buscar(obj);
            if (ventaEncontrada != null)
            {
                ventaEncontrada.Id = obj.Id;
                ventaEncontrada.Valor = obj.Valor;
                ventaEncontrada.Fecha = obj.Fecha;
                ventaEncontrada.Barbero = obj.Barbero;
                ventaEncontrada.Usuario = obj.Usuario;
                ventaEncontrada.DetalleServicio = obj.DetalleServicio;
                appContexts.SaveChanges();
            }
            return ventaEncontrada;
        }

        public Venta Adicionar(Venta obj)
        {
            var venta = appContexts.Ventas.Add(obj);
            appContexts.SaveChanges();
            return venta.Entity;
        }

        public Venta Buscar(Venta obj)
        {
            return appContexts.Ventas.FirstOrDefault(v => v.Id == obj.Id);
        }

        public IEnumerable<Venta> Consultar()
        {
            return appContexts.Ventas;
        }

        public int Eliminar(Venta obj)
        {
            int result = 0;
            var ventaEncontrada = Buscar(obj);
            if (ventaEncontrada == null)
                return result;
            appContexts.Ventas.Remove(obj);
            result = appContexts.SaveChanges();
            return result;
        }
    }
}
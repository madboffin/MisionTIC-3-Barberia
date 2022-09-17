using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BarberManager.Dominio;

namespace BarberManager.Persistencia
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
            var ventaEncontrada = Buscar(obj.Id);
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

        public Venta Buscar(int Id)
        {
            return appContexts.Ventas.FirstOrDefault(v => v.Id == Id);
        }

        public IEnumerable<Venta> Consultar()
        {
            return appContexts.Ventas;
        }

        public int Eliminar(int Id)
        {
            int result = 0;
            var ventaEncontrada = Buscar(Id);
            if (ventaEncontrada == null)
                return result;
            appContexts.Ventas.Remove(ventaEncontrada);
            result = appContexts.SaveChanges();
            return result;
        }
    }
}
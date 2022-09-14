using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BarberManager.Dominio;

namespace BarberManager.Persistencia
{
    public class RespositorioServicio : ICRUD<Servicio>
    {
        private readonly AppContexts appContexts;
        public RespositorioServicio(AppContexts appContexts)
        {
            this.appContexts = appContexts;
        }

        public Servicio Actualizar(Servicio obj)
        {
            var servicioEncontrado = Buscar(obj);
            if (servicioEncontrado != null){
                servicioEncontrado.Id = obj.Id;
                servicioEncontrado.Nombre = obj.Nombre;
                servicioEncontrado.Precio = obj.Precio;
                appContexts.SaveChanges();
            }
            return servicioEncontrado;
        }

        public Servicio Adicionar(Servicio obj)
        {
            var servicio = appContexts.Sevicios.Add(obj);
            appContexts.SaveChanges();
            return servicio.Entity;
        }

        public Servicio Buscar(Servicio obj)
        {
            return appContexts.Sevicios.FirstOrDefault(s => s.Id == obj.Id);
        }

        public IEnumerable<Servicio> Consultar()
        {
            return appContexts.Sevicios;
        }

        public int Eliminar(Servicio obj)
        {
            int result = 0;
            var servicioEncontrado = Buscar(obj);
            if (servicioEncontrado == null)
                return result;
            appContexts.Sevicios.Remove(obj);
            result = appContexts.SaveChanges();
            return result;
        }
    }
}
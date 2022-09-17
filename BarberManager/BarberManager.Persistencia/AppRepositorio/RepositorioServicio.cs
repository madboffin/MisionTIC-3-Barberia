using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BarberManager.Dominio;

namespace BarberManager.Persistencia
{
    public class RepositorioServicio : ICRUD<Servicio>
    {
        private readonly AppContexts appContexts;
        public RepositorioServicio(AppContexts appContexts)
        {
            this.appContexts = appContexts;
        }

        public Servicio Actualizar(Servicio obj)
        {
            var servicioEncontrado = Buscar(obj.Id);
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

        public Servicio Buscar(int Id)
        {
            return appContexts.Sevicios.FirstOrDefault(s => s.Id == Id);
        }

        public IEnumerable<Servicio> Consultar()
        {
            return appContexts.Sevicios;
        }

        public int Eliminar(int Id)
        {
            int result = 0;
            var servicioEncontrado = Buscar(Id);
            if (servicioEncontrado == null)
                return result;
            appContexts.Sevicios.Remove(servicioEncontrado);
            result = appContexts.SaveChanges();
            return result;
        }
    }
}
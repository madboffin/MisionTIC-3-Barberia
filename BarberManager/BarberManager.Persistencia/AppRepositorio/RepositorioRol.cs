using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BarberManager.Dominio;

namespace BarberManager.Persistencia.AppRepositorio
{
    public class RepositorioRol : ICRUD<Rol>
    {
        private readonly AppContexts appContexts;
        public RepositorioRol(AppContexts appContexts)
        {
            this.appContexts = appContexts;
        }

        public Rol Actualizar(Rol obj)
        {
            var rolEncontrado = Buscar(obj);
            if (rolEncontrado != null)
            {
                rolEncontrado.Id = obj.Id;
                rolEncontrado.Nombre = obj.Nombre;
                appContexts.SaveChanges();
            }
            return rolEncontrado;
        }

        public Rol Adicionar(Rol obj)
        {
            var rol = appContexts.Roles.Add(obj);
            appContexts.SaveChanges();
            return rol.Entity;
        }

        public Rol Buscar(Rol obj)
        {
            return appContexts.Roles.FirstOrDefault(r => r.Id == obj.Id);
        }

        public IEnumerable<Rol> Consultar()
        {
            return appContexts.Roles;
        }

        public int Eliminar(Rol obj)
        {
            int result = 0;
            var rolEncontrado = Buscar(obj);
            if (rolEncontrado == null)
                return result;
            appContexts.Roles.Remove(obj);
            result = appContexts.SaveChanges();
            return result;
        }
    }
}
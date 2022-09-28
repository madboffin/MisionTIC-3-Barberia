using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BarberManager.Dominio;

namespace BarberManager.Persistencia {
    public class RepositorioRol : ICRUD<Rol> {
        private readonly AppContexts appContexts;
        public RepositorioRol(AppContexts appContexts) {
            this.appContexts = appContexts;
        }

        public Rol Actualizar(Rol obj) {
            var rolEncontrado = Buscar(obj.Id);
            if (rolEncontrado != null)
            {
                rolEncontrado.Id = obj.Id;
                rolEncontrado.Nombre = obj.Nombre;
                appContexts.SaveChanges();
            }
            return rolEncontrado;
        }

        public Rol Adicionar(Rol obj) {
            var rol = appContexts.Roles.Add(obj);
            appContexts.SaveChanges();
            return rol.Entity;
        }

        public Rol Buscar(int Id) {
            return appContexts.Roles.FirstOrDefault(r => r.Id == Id);
        }

        public IEnumerable<Rol> Consultar() {
            return appContexts.Roles;
        }

        public int Eliminar(int Id) {
            int result = 0;
            var rolEncontrado = Buscar(Id);
            if (rolEncontrado == null)
                return result;
            appContexts.Roles.Remove(rolEncontrado);
            result = appContexts.SaveChanges();
            return result;
        }
    }
}
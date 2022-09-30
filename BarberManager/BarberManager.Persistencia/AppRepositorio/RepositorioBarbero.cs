using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BarberManager.Dominio;

namespace BarberManager.Persistencia {
    public class RepositorioBarbero : ICRUD<Barbero> {
        private readonly AppContexts appContexts;
        public RepositorioBarbero(AppContexts appContexts) {
            this.appContexts = appContexts;
        }

        public Barbero Actualizar(Barbero obj) {
            var barberoEncontrado = Buscar(obj.Id);
            if (barberoEncontrado != null) {
                barberoEncontrado.Id = obj.Id;
                barberoEncontrado.TipoDocumento = obj.TipoDocumento;
                barberoEncontrado.Documento = obj.Documento;
                barberoEncontrado.Nombre = obj.Nombre;
                barberoEncontrado.Telefono = obj.Telefono;
                barberoEncontrado.Correo = obj.Correo;
                barberoEncontrado.Usuario = obj.Usuario;
                appContexts.SaveChanges();
            }
            return barberoEncontrado;
        }

        public Barbero Adicionar(Barbero obj) {
            var barbero = appContexts.Barberos.Add(obj);
            appContexts.SaveChanges();
            return barbero.Entity;
        }

        public Barbero Buscar(int Id) {
            return appContexts.Barberos.FirstOrDefault(b => b.Id == Id);
        }

        public IEnumerable<Barbero> Consultar() {
            return appContexts.Barberos.Include(b=>b.Usuario);
        }

        public int Eliminar(int Id) {
            int result = 0;
            var barberoEncontrado = Buscar(Id);
            if (barberoEncontrado == null)
                return result;
            appContexts.Barberos.Remove(barberoEncontrado);
            result = appContexts.SaveChanges();
            return result;
        }
    }
}
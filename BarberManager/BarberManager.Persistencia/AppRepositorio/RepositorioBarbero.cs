using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BarberManager.Dominio;

namespace BarberManager.Persistencia.AppRepositorio
{
    public class RepositorioBarbero : ICRUD<Barbero>
    {
        private readonly AppContexts appContexts;
        public RepositorioBarbero(AppContexts appContexts)
        {
            this.appContexts = appContexts;
        }

        public int Actualizar(Barbero obj)
        {
            int result = 0;
            var barberoEncontrado = appContexts.Barbero.FirstOrDefault(b => b.Id == obj.Id);
            if (barberoEncontrado != null){
                barberoEncontrado.Id = obj.Id;
                barberoEncontrado.TipoDocumento = obj.TipoDocumento;
                barberoEncontrado.Documento = obj.Documento;
                barberoEncontrado.Nombre = obj.Nombre;
                barberoEncontrado.Telefono = obj.Telefono;
                barberoEncontrado.Correo = obj.Correo;
                barberoEncontrado.Id_usuario = obj.Id_usuario;
                result = appContexts.SaveChanges();
            }
            return result;
        }

        public int Adicionar(Barbero obj)
        {
            var barbero = appContexts.Barbero.Add(obj);
            int result = appContexts.SaveChanges();
            return result;
        }

        public Barbero Buscar(Barbero obj)
        {
            return appContexts.Barbero.FirstOrDefault(b => b.Id == obj.Id);
        }

        public IEnumerable<Barbero> Consultar()
        {
            return appContexts.Barbero;
        }

        public int Eliminar(Barbero obj)
        {
            int result = 0;
            var barberoEncontrado = appContexts.Barbero.FirstOrDefault(b => b.Id == obj.Id);
            if (barberoEncontrado == null)
                return result;
            appContexts.Barbero.Remove(barberoEncontrado);
            appContexts.SaveChanges();
            return result;
        }
    }
}
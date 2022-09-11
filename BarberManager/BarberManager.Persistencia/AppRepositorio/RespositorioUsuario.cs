using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BarberManager.Dominio;

namespace BarberManager.Persistencia.AppRepositorio
{
    public class RespositorioUsuario : ICRUD<Usuario>
    {
        private readonly AppContexts appContexts;
        public RespositorioUsuario(AppContexts appContexts)
        {
            this.appContexts = appContexts;
        }

        public Usuario Actualizar(Usuario obj)
        {
            var usuarioEncontrado = Buscar(obj);
            if (usuarioEncontrado != null)
            {
                usuarioEncontrado.Id = obj.Id;
                usuarioEncontrado.Nombre = obj.Nombre;
                usuarioEncontrado.Contrasena = obj.Contrasena;
                usuarioEncontrado.Rol = obj.Rol;
                usuarioEncontrado.Estado = obj.Estado;
                usuarioEncontrado.Correo = obj.Correo;
                appContexts.SaveChanges();
            }
            return usuarioEncontrado;
        }

        public Usuario Adicionar(Usuario obj)
        {
            var usuario = appContexts.Usuarios.Add(obj);
            appContexts.SaveChanges();
            return usuario.Entity;
        }

        public Usuario Buscar(Usuario obj)
        {
            return appContexts.Usuarios.FirstOrDefault(u => u.Id == obj.Id);
        }

        public IEnumerable<Usuario> Consultar()
        {
            return appContexts.Usuarios;
        }

        public int Eliminar(Usuario obj)
        {
            int result = 0;
            var usuarioEncontrado = Buscar(obj);
            if (usuarioEncontrado == null)
                return result;
            appContexts.Usuarios.Remove(obj);
            result = appContexts.SaveChanges();
            return result;
        }
    }
}
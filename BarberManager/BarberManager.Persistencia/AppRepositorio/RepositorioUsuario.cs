using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BarberManager.Dominio;

namespace BarberManager.Persistencia
{
    public class RepositorioUsuario : ICRUD<Usuario>
    {
        private readonly AppContexts appContexts;
        public RepositorioUsuario(AppContexts appContexts)
        {
            this.appContexts = appContexts;
        }

        public Usuario Actualizar(Usuario obj)
        {
            var usuarioEncontrado = Buscar(obj.Id);
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

        public Usuario Buscar(int Id)
        {
            return appContexts.Usuarios.FirstOrDefault(u => u.Id == Id);
        }

        public IEnumerable<Usuario> Consultar()
        {
            return appContexts.Usuarios.Include(p=>p.Rol);
        }

        public int Eliminar(int Id)
        {
            int result = 0;
            var usuarioEncontrado = Buscar(Id);
            if (usuarioEncontrado == null)
                return result;
            appContexts.Usuarios.Remove(usuarioEncontrado);
            result = appContexts.SaveChanges();
            return result;
        }
    }
}
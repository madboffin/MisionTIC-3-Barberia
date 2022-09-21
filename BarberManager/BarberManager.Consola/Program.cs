
using System;
using BarberManager.Dominio;
using BarberManager.Persistencia;

namespace BarberManager.Consola // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        private static ICRUD<Rol> _repositorioRol = new RepositorioRol(new BarberManager.Persistencia.AppContexts());
        private static ICRUD<Servicio> _repositorioServicio = new RepositorioServicio(new BarberManager.Persistencia.AppContexts());
        static void Main(string[] args)
        {
            // var resultadoRol = _repositorioRol.Consultar();
            // foreach (var rol in resultadoRol)
            // {
            //     Console.Write(rol.Id + " ");
            //     Console.WriteLine(rol.Nombre);
            // }
            // crearServicio();
            consultarServicio();
            actualizarServicio();
            consultarServicio();
        }
        public static void crearServicio()
        {
            var _servicio = new Servicio
            {
                Nombre = "testServicio",
                Precio = 30000,
            };
            var _servicioAdicionado = _repositorioServicio.Adicionar(_servicio);
            if (_servicioAdicionado == null)
            {
                Console.WriteLine("Error al crear el servicio");
            } else {
                Console.WriteLine("Servicio creado");
            };
        }
        public static void consultarServicio()
        {
            var _servicio = _repositorioServicio.Buscar(4);
            if (_servicio != null)
            {
                Console.WriteLine(_servicio.Nombre + " " + _servicio.Precio);
            }
        }

        public static void actualizarServicio(){
            var _servicio = _repositorioServicio.Buscar(4);
            _servicio.Nombre = _servicio.Nombre+"_";
            var _servicioActualizado = _repositorioServicio.Actualizar(_servicio);
            if (_servicioActualizado==null){ }
        }
        public static void eliminarServicio(){
            var _servicioEliminado = _repositorioServicio.Eliminar(4);
            if (_servicioEliminado==0){ }
        }
    }
}
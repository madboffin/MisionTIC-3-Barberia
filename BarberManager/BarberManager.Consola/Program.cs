
using System;
using BarberManager.Dominio;
using BarberManager.Persistencia;

namespace BarberManager.Consola // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        private static ICRUD<Rol> _repositorioRol = new RepositorioRol(new BarberManager.Persistencia.AppContexts());
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var resultadoRol = _repositorioRol.Consultar();
            foreach (var rol in resultadoRol)
            {
                Console.Write(rol.Id + " ");
                Console.WriteLine(rol.Nombre);
            }
        }
    }
}
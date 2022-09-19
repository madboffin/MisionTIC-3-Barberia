using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Web;
using BarberManager.Dominio;
using BarberManager.Persistencia;

namespace BaberManager.Frontend
{
    public class RolesCrearModel : PageModel
    {
        private static ICRUD<Rol> _repositorioRol = new RepositorioRol(new BarberManager.Persistencia.AppContexts());
        public void OnGet()
        {

        }
        public void OnPost() {
            string nombre = Request.Form["nombreRol"];
            //TODO validar datos
            /*int costo = 0;
            if (!Int32.TryParse(_costo, out costo))
            { Console.WriteLine("Error al guardar el costo");
                return;
            }*/

            var Rol = new Rol { 
                Nombre = nombre,
                
            };

            var RolAdicionado = _repositorioRol.Adicionar(Rol);
            if (RolAdicionado == null) {
                Console.WriteLine("Error al guardar el servicio");
                return;
            }
            else {
                Console.WriteLine("Guardado exitosamente");
                return;
            }
        }
    }
}


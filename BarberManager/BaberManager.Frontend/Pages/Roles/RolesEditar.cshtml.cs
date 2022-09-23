using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Web;
using BarberManager.Dominio;
using BarberManager.Persistencia;

namespace BaberManager.Frontend
{
    public class RolesEditarModel : PageModel
    {
        private static ICRUD<Rol> _repositorioRol = new RepositorioRol(
            new BarberManager.Persistencia.AppContexts()
        );
        public Rol rol = new Rol();

        public IActionResult OnGet(int Id)
        {
            var rol = _repositorioRol.Buscar(Id);
            if (rol == null)
            {
                return RedirectToPage("./Roles");
            }
            else
            {
                Console.WriteLine(rol.Id + rol.Nombre);
                return Page();
            }
        }

        public IActionResult Onpost()
        {
           
            Console.WriteLine(rol.Id + rol.Nombre);

            string id = Request.Form["idRol"];
            string nombre = Request.Form["nombreRol"];
            rol.Nombre = nombre;
            Console.WriteLine(rol.Id + rol.Nombre);

            var RolAdicionado = _repositorioRol.Actualizar(rol);
            if (RolAdicionado == null)
            {
                ViewData["mensaje"] = "No se puedo actualizar";
                Console.WriteLine("Error al guardar el Rol");
            }
            else
            {
                ViewData["mensaje"] = "Guardado exitosamente";
                Console.WriteLine("Guardado exitosamente");
            }
            return RedirectToPage("./Roles");
        }
    }
}

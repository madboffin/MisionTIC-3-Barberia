using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Web;
using BarberManager.Dominio;
using BarberManager.Persistencia;

namespace BaberManager.Frontent
{
    public class ServiciosEditarModel : PageModel
    {
        private static ICRUD<Servicio> _repositorioServicio = new RepositorioServicio(new BarberManager.Persistencia.AppContexts());
        public Servicio servicio = new Servicio();
        public IActionResult OnGet(int Id)
        {
            var servicio = _repositorioServicio.Buscar(Id);
            if (servicio == null)
            {
                return RedirectToPage("./Servicios");
            }
            else
            {
                Console.WriteLine(servicio.Nombre);
                Console.WriteLine(servicio.Precio);
                return Page();
            }
        }
    }
}

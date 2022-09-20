using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Web;
using BarberManager.Dominio;
using BarberManager.Persistencia;

namespace BaberManager.Frontend
{
    public class ServiciosEditarModel : PageModel
    {
        private static ICRUD<Servicio> _repositorioServicio = new RepositorioServicio(new BarberManager.Persistencia.AppContexts());
        public Servicio servicio = new Servicio();
        public IActionResult OnGet(int Id) {
            var servicio = _repositorioServicio.Buscar(Id);
            if (servicio == null) {
                return RedirectToPage("./Servicios");
            }
            else {
                Console.WriteLine(servicio.Id + servicio.Nombre + servicio.Precio);
                return Page();
            }
        }

        public IActionResult Onpost() {
            Console.WriteLine(servicio.Id + servicio.Nombre + servicio.Precio);
            string id = Request.Form["idServicio"];
            string nombre = Request.Form["nombreServicio"];
            string _costo = Request.Form["costoServicio"];

            //TODO validar datos
            int costo = 0;
            if (!Int32.TryParse(_costo, out costo)) { 
                Console.WriteLine("Error al guardar el costo");
                ViewData["mensaje"] = "Error al guardar el costo";
                return new EmptyResult();
            }

            servicio.Nombre = nombre;
            servicio.Precio = costo;
            Console.WriteLine(servicio.Id + servicio.Nombre + servicio.Precio);

            var servidioAdicionado = _repositorioServicio.Actualizar(servicio);
            if (servidioAdicionado == null) {
                ViewData["mensaje"] = "No se puedo actualizar";
                Console.WriteLine("Error al guardar el servicio");
            }
            else {
                ViewData["mensaje"] = "Guardado exitosamente";
                Console.WriteLine("Guardado exitosamente");
            }
            return RedirectToPage("./Servicios");
        }
    }
}

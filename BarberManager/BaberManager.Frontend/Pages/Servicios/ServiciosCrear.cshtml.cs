using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Web;
using BarberManager.Dominio;
using BarberManager.Persistencia;
namespace BaberManager.Frontent {
    public class ServiciosCrearModel : PageModel {
        private static ICRUD<Servicio> _repositorioServicio = new RepositorioServicio(new BarberManager.Persistencia.AppContexts());
        public void OnGet() { }
        public void OnPost() {
            string nombre = Request.Form["nombreServicio"];
            string _costo = Request.Form["costoServicio"];

            int costo = 0;
            if (!Int32.TryParse(_costo, out costo)) {
                Console.WriteLine("Error al guardar el costo");
                return;
            }

            //TODO validar datos
            var servicio = new Servicio {
                Nombre = nombre,
                Precio = costo
            };

            var servidioAdicionado = _repositorioServicio.Adicionar(servicio);
            if (servidioAdicionado==null) {
                Console.WriteLine("Error al guardar el servicio");
                return;
            } else {
                Console.WriteLine("Guardado exitosamente");
                return;
            }
        }
    }
}

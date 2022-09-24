using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Web;
using BarberManager.Dominio;
using BarberManager.Persistencia;
namespace BaberManager.Frontend {
    public class ServiciosCrearModel : PageModel {
        private static ICRUD<Servicio> _repositorioServicio = new RepositorioServicio(new BarberManager.Persistencia.AppContexts());
        public void OnGet() { }
        public void OnPost() {
            string nombre = Request.Form["nombreServicio"];
            string _costo = Request.Form["costoServicio"];

            //TODO validar datos
            int costo = 0;
            if (!Int32.TryParse(_costo, out costo))
            { Console.WriteLine("Error al guardar el costo");
                return;
            }

            var servicio = new Servicio { 
                Nombre = nombre,
                Precio = costo
            };

            var servicioAdicionado = _repositorioServicio.Adicionar(servicio);
            if (servicioAdicionado == null) {
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

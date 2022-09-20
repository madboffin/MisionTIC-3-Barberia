using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BarberManager.Dominio;
using BarberManager.Persistencia;

namespace BaberManager.Frontend
{
    public class ServiciosModel : PageModel
    {
        private static ICRUD<Servicio> _repositorioServicio = new RepositorioServicio(new BarberManager.Persistencia.AppContexts());
        public List<Servicio> listaServicios = new List<Servicio>();
        public void OnGet()
        {
            listaServicios = _repositorioServicio.Consultar().ToList();
        }
        public IActionResult OnPostCreate([FromBody] Servicio _servicio)
        {
            //TODO validar datos
            var servidioAdicionado = _repositorioServicio.Adicionar(_servicio);
            if (servidioAdicionado == null) {
                return Content("Error al guardar el servicio");
            }
            else { }
            return Content("Guardado exitosamente");
        }
    }
}

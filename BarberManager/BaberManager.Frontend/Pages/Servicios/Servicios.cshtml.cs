using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BarberManager.Dominio;
using BarberManager.Persistencia;

namespace BaberManager.Frontend {
    public class ServiciosModel : PageModel {
        private static ICRUD<Servicio> _repositorioServicio = new RepositorioServicio(new BarberManager.Persistencia.AppContexts());
        public List<Servicio> listaServicios = new List<Servicio>();
        public void OnGet() {
            listaServicios = _repositorioServicio.Consultar().ToList();
        }
        public IActionResult OnPostCreate([FromBody] Servicio _servicio) {
            //TODO validar datos
            var servidioAdicionado = _repositorioServicio.Adicionar(_servicio);
            if (servidioAdicionado == null) {
                return Content("Error al guardar el servicio");
            } else { }
            return Content("Guardado exitosamente");
        }
        public IActionResult OnPostDelete([FromBody] int Id) {
            var result = _repositorioServicio.Eliminar(Id);
            if (result == 0) {
                return Content("No se pudo elminar");
            } else {
                return Content("Eliminado correctamente");
            }
        }
        public IActionResult OnPostEdit([FromBody] Servicio servicio) {
            var result = _repositorioServicio.Actualizar(servicio);
            if (result == null) {
                return Content("No se pudo actualizar");
            } else {
                return Content("Actualizado correctamente");
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BarberManager.Persistencia;
using BarberManager.Dominio;

namespace BaberManager.Frontent {
    public class UsuariosModel : PageModel {
        private static ICRUD<Usuario> _repositorioUsuario = new RepositorioUsuario(new BarberManager.Persistencia.AppContexts());
        private static ICRUD<Rol> _repositorioRol = new RepositorioRol(new BarberManager.Persistencia.AppContexts());
        public List<Usuario> listaUsuarios {get; set;} = new List<Usuario>();
        public List<Rol> listaRoles {get; set;} = new List<Rol>();
        public void OnGet() { 
            listaUsuarios = _repositorioUsuario.Consultar().ToList();
            listaRoles = _repositorioRol.Consultar().ToList();
        }
        public void OnPostCreate([FromBody] Usuario _usuario) {}
        public void OnPostEdit([FromBody] int Id) {}
        public IActionResult OnPostDelete([FromBody] int Id) {
            var result = _repositorioUsuario.Eliminar(Id);
            if (result != 0) {
                return Content("Eliminado correctamente");
            }
            return Content("No se pudo eliminar");
        }
    }
}
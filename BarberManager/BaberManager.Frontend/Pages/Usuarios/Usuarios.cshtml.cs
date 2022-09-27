using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BarberManager.Persistencia;
using BarberManager.Dominio;

namespace BaberManager.Frontent {
    public class UsuariosModel : PageModel {
        private static ICRUD<Usuario> _repositorioUsuario = new RepositorioUsuario(new BarberManager.Persistencia.AppContexts());
        private static ICRUD<Rol> _repositorioRol = new RepositorioRol(new BarberManager.Persistencia.AppContexts());
        public List<Usuario> listaUsuarios {get; set;} = new List<Usuario>();
        public void OnGet() { 
            listaUsuarios = _repositorioUsuario.Consultar().ToList();
        }
        public void OnPost() {
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BarberManager.Dominio;
using BarberManager.Persistencia;


namespace BaberManager.Frontend
{
    public class RolesModel : PageModel
    {
        private static ICRUD<Rol> _repositorioRol = new RepositorioRol(new BarberManager.Persistencia.AppContexts());
        public List<Rol> listaRoles = new List<Rol>();
        public void OnGet()
        {
            listaRoles = _repositorioRol.Consultar().ToList();
        }
    }
}


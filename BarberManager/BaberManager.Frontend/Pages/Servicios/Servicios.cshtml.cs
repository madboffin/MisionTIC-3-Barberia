using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BarberManager.Dominio;
using BarberManager.Persistencia;

namespace BaberManager.Frontent
{
    public class ServiciosModel : PageModel
    {
        private static ICRUD<Rol> _repositorioRol = new RepositorioRol(new BarberManager.Persistencia.AppContexts());
        private static ICRUD<Servicio> _repositorioServicio = new RepositorioServicio(new BarberManager.Persistencia.AppContexts());
        public List<Rol> listaRoles = new List<Rol>();
        public List<Servicio> listaServicios = new List<Servicio>();
        public void OnGet()
        {
            listaRoles = _repositorioRol.Consultar().ToList();
        }
    }
}

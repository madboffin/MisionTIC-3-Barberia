using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BarberManager.Dominio;
using BarberManager.Persistencia;

namespace BaberManager.Frontent
{
    public class ServiciosEditarModel : PageModel
    {
        private static ICRUD<Servicio> _repositorioServicio = new RepositorioServicio(new BarberManager.Persistencia.AppContexts());
        private static ICRUD<Rol> _repositorioRol = new RepositorioRol(new BarberManager.Persistencia.AppContexts());
        public Servicio servicio = new Servicio();
        public Rol rol = new Rol();
        public void OnGet(int Id)
        {
            var servicio = _repositorioServicio.Buscar(Id);
            var rol = _repositorioRol.Buscar(Id);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BarberManager.Dominio;
using BarberManager.Persistencia;

namespace BaberManager.Frontend
{
    public class BarberoModel : PageModel
    {
        private static ICRUD<Barbero> _repositorioBarbero = new RepositorioBarbero(new BarberManager.Persistencia.AppContexts());
        public List<Barbero> listaBarberos = new List<Barbero>();
        public void OnGet() {
            listaBarberos = _repositorioBarbero.Consultar().ToList();
        }
        
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BarberManager.Persistencia;
using BarberManager.Dominio;

namespace BaberManager.Frontend {
    public class BarberoModel : PageModel {
        private static ICRUD<Barbero> _repositorioBarbero = new RepositorioBarbero(new BarberManager.Persistencia.AppContexts());
        public List<Barbero> listaBarberos {get; set;} = new List<Barbero>();
        public void OnGet() { 
            listaBarberos = _repositorioBarbero.Consultar().ToList();
        }
    }
}

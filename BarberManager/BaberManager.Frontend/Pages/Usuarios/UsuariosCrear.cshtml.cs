using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BarberManager.Dominio;
using BaberManager.Frontend;
using BarberManager.Persistencia;

namespace BaberManager.Frontend {
    public class UsuariosCrearModel : PageModel {
        private static ICRUD<Usuario> _repositorioUsuario = new RepositorioUsuario(new BarberManager.Persistencia.AppContexts());
        private static ICRUD<Rol> _repositorioRol = new RepositorioRol(new BarberManager.Persistencia.AppContexts());

        // Inicializa variable, por alguna razon es necesario definir getters y setters
        public List<Rol> listaRoles {get; set;} = new List<Rol>();
        public void OnGet() { 
            listaRoles = _repositorioRol.Consultar().ToList();
         }
        public IActionResult OnPost() {
            int rolId = Int32.Parse(Request.Form["rolUsuario"]);
            string nombre = Request.Form["nombreUsuario"];
            string contrasena = Request.Form["contrasenaUsuario"];
            string _estado = Request.Form["estadoUsuario"];
            string correo = Request.Form["correoUsuario"];

            int estado = 0;
            if (!Int32.TryParse(_estado, out estado)) {
                return Content("Error al guardar el estado");
            }
            var rol = _repositorioRol.Buscar(rolId);
            if (rol==null){
                return Content("Usuario nulo");
            }
            Console.WriteLine(rol.Id + " " + rol.Nombre);
            //TODO validar datos
            var _usuario = new Usuario {
                Nombre = nombre,
                Contrasena = contrasena,
                Estado = estado,
                Correo = correo
            };

            // El rol se adiciona luego de crear el usuario, 
            // de lo contrario EF intenta crear un nuevo rol
            var _usuarioAdicionado = _repositorioUsuario.Adicionar(_usuario);
            _usuario.Rol = rol;
            var usuarioAdicionado = _repositorioUsuario.Actualizar(_usuario);
            if (usuarioAdicionado == null) {
                return Content("Error al guardar el Usuario");
            } else {
                return Content("Guardado exitosamente");
            }
        }
    }
}

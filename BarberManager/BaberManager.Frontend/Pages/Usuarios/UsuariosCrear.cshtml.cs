using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BarberManager.Dominio;
using BaberManager.Frontend;
using BarberManager.Persistencia;

namespace BaberManager.Frontend
{
    public class UsuariosCrearModel : PageModel
    {
           private static ICRUD<Usuario> _repositorioUsuario = new RepositorioUsuario(new BarberManager.Persistencia.AppContexts());
        public void OnGet() { }
        public void OnPost() {

            string nombre = Request.Form["nombreUsuario"];
            string contrasena = Request.Form["contrasenaUsuario"];
            string rol = Request.Form["rolUsuario"];
            string _estado = Request.Form["estadoUsuario"];
            string correo = Request.Form["correoUsuario"];

            int estado = 0;
            Console.WriteLine(_estado);
            if (!Int32.TryParse(_estado, out estado))
            { Console.WriteLine("Error al guardar el estado");
                return;
            }
        
            //TODO validar datos
            
            var Usuario = new Usuario { 
                Nombre = nombre,
                Contrasena = contrasena,
                Rol = new  Rol {
                    Nombre = rol
                },
                Estado = estado,
                Correo = correo
                
            };

            var usuarioAdicionado = _repositorioUsuario.Adicionar(Usuario);
            if (usuarioAdicionado == null) {
                Console.WriteLine("Error al guardar el Usuario");
                return;
            }
            else {
                Console.WriteLine("Guardado exitosamente");
                return;
            }
            
            

        }
   
    }
}

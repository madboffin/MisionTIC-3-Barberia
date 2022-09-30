using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;

namespace BaberManager.Frontend {
    public class LoginModel : PageModel {
        public const string _sessionIdUser = "_idUser";
        public const string _sessionIdRol = "_idRol";
        private IHttpContextAccessor _httpContextAccessor = default!;
        public LoginModel(IHttpContextAccessor httpContextAccessor){
            _httpContextAccessor = httpContextAccessor;
        }
        public class LoginInfo {
            public string Usuario { get; set; } = default!;
            public string Password { get; set; } = default!;
        }

        public void OnGet() { }
        public IActionResult OnPostValidateLogin([FromBody] LoginInfo loginfo) {
            //Validar datos

            if (loginfo.Usuario=="Juank" && loginfo.Password=="1234"){
                var rol = "admin";
                var idUser = "1000";

                // Da acceso a la sesion
                _httpContextAccessor.HttpContext.Session.SetString(_sessionIdUser, idUser);
                _httpContextAccessor.HttpContext.Session.SetString(_sessionIdRol, rol);

                Console.WriteLine("Contenido de sesion: "+ _httpContextAccessor.HttpContext.Session.GetString(_sessionIdUser));
                Console.WriteLine("Contenido de rol: "+ _httpContextAccessor.HttpContext.Session.GetString(_sessionIdRol));
                switch (rol) {
                    case "admin": return Content("Index");
                    case "recepcion": return Content("Servicios/Servicios");
                    default: return Content("");
                }
            }
            return Content("invalido");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BaberManager.Frontend
{
    public class LoginModel : PageModel
    {
        public void OnGet()
        {
        }
        public void OnPost()
        {
            Console.WriteLine("On post()");
            //validar datos
            // return RedirectPage("../Servicios/Servicios");
        }
    }
}

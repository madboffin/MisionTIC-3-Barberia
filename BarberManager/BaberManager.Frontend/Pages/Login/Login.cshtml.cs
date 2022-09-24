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
        }

        public IActionResult OnPostValidateLogin(string Usuario, string Password){
            return Content(Usuario + "-" + Password);
        }
        public void ConfigureServices(IServiceCollection services){
            services.AddRazorPages();
            services.AddHttpContextAccessor();
            services.AddSession(options => {
                options.Cookie.HttpOnly = true;
                options.Cookie.Name = ".BarberManager.Session";
                options.Cookie.IsEssential = true;
            });
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BaberManager.Frontend
{
    public class LoginModel : PageModel
    {
        public void OnGet()
        {
            Console.WriteLine("On get()");
        }
        public void OnPost()
        {
            Console.WriteLine("On post()");
        }
    }
}

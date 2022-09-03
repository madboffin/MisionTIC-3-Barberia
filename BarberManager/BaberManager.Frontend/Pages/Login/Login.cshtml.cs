using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace BaberManager.Frontend.Pages.Login
{
    public class Login : PageModel
    {
        private readonly ILogger<Login> _logger;

        public Login(ILogger<Login> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            Console.WriteLine("On get()");
        }
        public void OnPost(){
            Console.WriteLine("On post()");
        }
    }
}
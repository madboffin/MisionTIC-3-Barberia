using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;

namespace BaberManager.Frontend.Pages;
public class IndexModel : PageModel {
    public const string _sessionIdUser = "_idUser";
    public const string _sessionIdRol = "_idRol";
    private IHttpContextAccessor _httpContextAccessor;
    private readonly ILogger<IndexModel> _logger;
    public IndexModel(ILogger<IndexModel> logger, IHttpContextAccessor httpContextAccessor) {
        _logger = logger;
        _httpContextAccessor = httpContextAccessor;
        Console.WriteLine("Constructor index");
        Console.WriteLine("Index Contenido de sesion: " + _httpContextAccessor.HttpContext.Session.GetString(_sessionIdUser));
        Console.WriteLine("Index Contenido de rol: " + _httpContextAccessor.HttpContext.Session.GetString(_sessionIdRol));
    }

    public IActionResult OnGet() {
        if (string.IsNullOrEmpty(_httpContextAccessor.HttpContext.Session.GetString(_sessionIdUser))){
            Console.WriteLine("Falta iniciar sesion");
            return Page();
        } 
        Console.WriteLine("Sesion iniciada");
        return Page();
    }
}

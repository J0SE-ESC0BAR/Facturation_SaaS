using Microsoft.AspNetCore.Mvc;

namespace WebApp.UI.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/AccessDenied")]
        public IActionResult AccessDenied(string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    ViewData["ErrorMessage"] = "Página no encontrada";
                    ViewData["ErrorDescription"] = "Lo sentimos, la página que buscas no existe.";
                    break;
                case 403:
                    ViewData["ErrorMessage"] = "Acceso Denegado";
                    ViewData["ErrorDescription"] = "No tienes permisos para acceder a este recurso.";
                    break;
                default:
                    ViewData["ErrorMessage"] = "Error";
                    ViewData["ErrorDescription"] = "Ocurrió un error inesperado.";
                    break;
            }
            
            return View("Error");
        }
    }
}
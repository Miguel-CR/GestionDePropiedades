using Microsoft.AspNetCore.Mvc;

namespace GestionDePropiedades.Controllers
{
    public class PropertyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

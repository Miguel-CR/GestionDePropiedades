using Microsoft.AspNetCore.Mvc;

namespace GestionDePropiedades.Controllers
{
    public class OwnerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

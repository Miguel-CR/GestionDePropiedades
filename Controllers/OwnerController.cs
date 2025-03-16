using GestionDePropiedades.Models;
using GestionDePropiedades.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestionDePropiedades.Controllers
{
    public class OwnerController : Controller
    {
        private readonly IService<Owner> _ownerService;

        public OwnerController(IService<Owner> ownerService)
        {
            _ownerService = ownerService;
        }

        public IActionResult Index()
        {
            IEnumerable<Owner> owners = _ownerService.GetAll();
            return View(owners);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Owner owner)
        {
            if (ModelState.IsValid)
            {
                _ownerService.Add(owner);
                return RedirectToAction("Index");
            }
            return View(owner);
        }

        public IActionResult Edit(int id)
        {
            var owner = _ownerService.GetById(id);
            if (owner == null)
            {
                return NotFound();
            }
            return View(owner);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Owner owner)
        {
            if (ModelState.IsValid)
            {
                _ownerService.Update(owner);
                return RedirectToAction("Index");
            }
            return View(owner);
        }

        public IActionResult Delete(int id)
        {
            var owner = _ownerService.GetById(id);
            if (owner == null)
            {
                return NotFound();
            }
            return View(owner);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _ownerService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}

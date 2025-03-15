using GestionDePropiedades.Models;
using GestionDePropiedades.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestionDePropiedades.Controllers
{
    public class PropertyTypeController : Controller
    {
        private readonly IService<PropertyType> _propertyTypeService;

        public PropertyTypeController(IService<PropertyType> propertyTypeService)
        {
            _propertyTypeService = propertyTypeService;
        }

        public IActionResult Index()
        {
            IEnumerable<PropertyType> propertyTypes = _propertyTypeService.GetAll();
            return View(propertyTypes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PropertyType propertyType)
        {
            if (ModelState.IsValid)
            {
                _propertyTypeService.Add(propertyType);
                return RedirectToAction("Index");
            }
            return View(propertyType);
        }

        public IActionResult Edit(int id)
        {
            var propertyType = _propertyTypeService.GetById(id);
            if (propertyType == null)
            {
                return NotFound();
            }
            return View(propertyType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PropertyType propertyType)
        {
            if (ModelState.IsValid)
            {
                _propertyTypeService.Update(propertyType);
                return RedirectToAction("Index");
            }
            return View(propertyType);
        }

        public IActionResult Delete(int id)
        {
            var propertyType = _propertyTypeService.GetById(id);
            if (propertyType == null)
            {
                return NotFound();
            }
            return View(propertyType);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _propertyTypeService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}

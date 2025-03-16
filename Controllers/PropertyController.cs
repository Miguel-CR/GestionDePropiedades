using GestionDePropiedades.Data;
using GestionDePropiedades.DTO;
using GestionDePropiedades.Models;
using GestionDePropiedades.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GestionDePropiedades.Controllers
{
    public class PropertyController : Controller
    {
        private readonly IServiceProperty _propertyService;
        private readonly IService<PropertyType> _propertyTypeService;
        private readonly IService<Owner> _ownerService;
        private readonly ApplicationDbContext _context; 

        public PropertyController(IServiceProperty propertyService, IService<PropertyType> propertyTypeService, IService<Owner> ownerService) 
        {
            _propertyService = propertyService;
            _propertyTypeService = propertyTypeService;
            _ownerService = ownerService;
        }

        public IActionResult Index()
        {
            IEnumerable<Property> properties = _propertyService.GetAllProperties();
            return View(properties);
        }

        public IActionResult Create()
        {
            var owners = _ownerService.GetAll();
            var propertyTypes = _propertyTypeService.GetAll();
            ViewBag.PropertyTypeId = new SelectList(propertyTypes, "Id", "Description");
            ViewBag.OwnerId = new SelectList(owners, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreatePropertyDto createPropertyDto)
        {
            Property property = null;
            if (ModelState.IsValid)
            {
                //NO agrego auto mapper por simplicidad y ademas no voy a instlar un nuget para solo un DTO
                property = new Property
                {
                    PropertyTypeId = createPropertyDto.PropertyTypeId,
                    OwnerId = createPropertyDto.OwnerId,
                    Number = createPropertyDto.Number,
                    Address = createPropertyDto.Address,
                    Area = createPropertyDto.Area,
                    ConstructionArea = createPropertyDto.ConstructionArea
                };
                _propertyService.Add(property);
                return RedirectToAction("Index");

            }
            var owners = _ownerService.GetAll();
            var propertyTypes = _propertyTypeService.GetAll();
            ViewBag.PropertyTypeId = new SelectList(propertyTypes, "Id", "Description", createPropertyDto.PropertyTypeId);
            ViewBag.OwnerId = new SelectList(owners, "Id", "Name", createPropertyDto.OwnerId);
            return View(property);
        }

        public IActionResult Edit(int id)
        {

            var property = _propertyService.GetById(id);
            var owners = _ownerService.GetAll();
            var propertyTypes = _propertyTypeService.GetAll();
            ViewBag.PropertyTypeId = new SelectList(propertyTypes, "Id", "Description");
            ViewBag.OwnerId = new SelectList(owners, "Id", "Name");
            if (property == null)
            {
                return NotFound();
            }
            return View(property);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CreatePropertyDto createPropertyDto)
        {
            Property property = null;
            if (ModelState.IsValid)
            {
                //NO agrego auto mapper por simplicidad y ademas no voy a instalar un nuget para solo un DTO
                property = new Property
                {
                    PropertyTypeId = createPropertyDto.PropertyTypeId,
                    OwnerId = createPropertyDto.OwnerId,
                    Number = createPropertyDto.Number,
                    Address = createPropertyDto.Address,
                    Area = createPropertyDto.Area,
                    ConstructionArea = createPropertyDto.ConstructionArea
                };
                _propertyService.Update(property);
                return RedirectToAction("Index");
            }
            var owners = _ownerService.GetAll();
            var propertyTypes = _propertyTypeService.GetAll();
            ViewBag.PropertyTypeId = new SelectList(propertyTypes, "Id", "Description", property.PropertyTypeId);
            ViewBag.OwnerId = new SelectList(owners, "Id", "Name", property.OwnerId);
            return View(property);
        }

        public IActionResult Delete(int id)
        {
            var property = _propertyService.GetById(id);
            if (property == null)
            {
                return NotFound();
            }
            return View(property);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _propertyService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}

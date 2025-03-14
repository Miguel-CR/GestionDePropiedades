using GestionDePropiedades.Models;
using GestionDePropiedades.Repository;

namespace GestionDePropiedades.Services
{
    public class PropertyTypeService : IService<PropertyType>
    {
        private readonly IRepository<PropertyType> _propertyTypeRepository;

        public PropertyTypeService(IRepository<PropertyType> propertyTypeRepository)
        {
            _propertyTypeRepository = propertyTypeRepository;
        }

        public IEnumerable<PropertyType> GetAll()
        {
            return _propertyTypeRepository.GetAll();
        }

        public PropertyType GetById(int id)
        {
            return _propertyTypeRepository.GetById(id);
        }

        public void Add(PropertyType entity)
        {
            _propertyTypeRepository.Add(entity);
        }

        public void Update(PropertyType entity)
        {
            _propertyTypeRepository.Update(entity);
        }

        public void Delete(int id)
        {
            _propertyTypeRepository.Delete(id);
        }
    }
}

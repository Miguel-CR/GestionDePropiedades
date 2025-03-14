using GestionDePropiedades.Models;
using GestionDePropiedades.Repository;

namespace GestionDePropiedades.Services
{
    public class PropertyService : IService<Property>
    {
        private readonly IRepository<Property> _propertyRepository;

        public PropertyService(IRepository<Property> propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        public IEnumerable<Property> GetAll()
        {
            return _propertyRepository.GetAll();
        }

        public Property GetById(int id)
        {
            return _propertyRepository.GetById(id);
        }

        public void Add(Property entity)
        {
            _propertyRepository.Add(entity);
        }

        public void Update(Property entity)
        {
            _propertyRepository.Update(entity);
        }

        public void Delete(int id)
        {
            _propertyRepository.Delete(id);
        }
    }
}

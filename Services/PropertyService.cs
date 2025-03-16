using GestionDePropiedades.Data;
using GestionDePropiedades.Models;
using GestionDePropiedades.Repository;
using Microsoft.EntityFrameworkCore;

namespace GestionDePropiedades.Services
{
    public class PropertyService : IServiceProperty
    {
        private readonly IRepository<Property> _propertyRepository;
        private readonly IRepositoryProperty _repositoryPropertyData;
        private readonly ApplicationDbContext _context;

        public PropertyService(IRepository<Property> propertyRepository,IRepositoryProperty repositoryPropertyData)
        {
            _propertyRepository = propertyRepository;
            _repositoryPropertyData = repositoryPropertyData;
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

        public IEnumerable<Property> GetAllProperties()
        {
            return _repositoryPropertyData.GetAllProperties();
        }
    }
}

using GestionDePropiedades.Models;
using GestionDePropiedades.Repository;

namespace GestionDePropiedades.Services
{
    public class OwnerService : IService<Owner>
    {
        private readonly IRepository<Owner> _ownerRepository;

        public OwnerService(IRepository<Owner> ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        public IEnumerable<Owner> GetAll()
        {
            return _ownerRepository.GetAll();
        }

        public Owner GetById(int id)
        {
            return _ownerRepository.GetById(id);
        }

        public void Add(Owner entity)
        {
            _ownerRepository.Add(entity);
        }

        public void Update(Owner entity)
        {
            _ownerRepository.Update(entity);
        }

        public void Delete(int id)
        {
            _ownerRepository.Delete(id);
        }
    }
}

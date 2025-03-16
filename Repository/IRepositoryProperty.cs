using GestionDePropiedades.Models;

namespace GestionDePropiedades.Repository
{
    public interface IRepositoryProperty
    {
        IEnumerable<Property> GetAllProperties();
    }
}

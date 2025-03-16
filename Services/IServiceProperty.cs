using GestionDePropiedades.Models;

namespace GestionDePropiedades.Services
{
    public interface IServiceProperty:IService<Property>
    {
        IEnumerable<Property> GetAllProperties();
    }
}

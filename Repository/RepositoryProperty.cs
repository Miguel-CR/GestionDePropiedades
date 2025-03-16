using GestionDePropiedades.Data;
using GestionDePropiedades.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionDePropiedades.Repository
{
    public class RepositoryProperty : IRepositoryProperty
    {
        private readonly ApplicationDbContext _context;
        public RepositoryProperty(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Property> GetAllProperties()
        {
            return _context.Properties
              .Include(p => p.PropertyType)
              .Include(p => p.Owner)
              .ToList();
        }
    }
}

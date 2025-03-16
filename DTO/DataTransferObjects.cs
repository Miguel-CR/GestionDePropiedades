using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestionDePropiedades.DTO
{
    public record CreatePropertyDto
    {
        [Required]
        public int PropertyTypeId { get; init; }

        [Required]
        public int OwnerId { get; init; }

        [Required(ErrorMessage = "El número es requerido.")]
        [MaxLength(255, ErrorMessage = "El número debe de tener máximo 255 caracteres")]
        public string Number { get; init; }

        [Required(ErrorMessage = "La dirección es requerida.")]
        [MaxLength(255, ErrorMessage = "La dirección debe de tener máximo 255 caracteres")]
        public string Address { get; init; }

        [Required(ErrorMessage = "El área es requerida.")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Area { get; init; }

        public decimal? ConstructionArea { get; init; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestionDePropiedades.Models
{
    public class Property
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int PropertyTypeId { get; set; }
        [ForeignKey("PropertyTypeId")]
        public virtual PropertyType PropertyType { get; set; } = null!;

        [Required]
        public int OwnerId { get; set; }
        [ForeignKey("OwnerId")]
        public virtual Owner Owner { get; set; } = null!;

        [Required(ErrorMessage = "El número es requerido.")]
        [MaxLength(255, ErrorMessage = "El número debe de tener máximo 255 caracteres")]
        public string Number { get; set; }

        [Required(ErrorMessage = "La dirección es requerida.")]
        [MaxLength(255, ErrorMessage = "La dirección debe de tener máximo 255 caracteres")]
        public string Address { get; set; }

        [Required(ErrorMessage = "El área es requerida.")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Area { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? ConstructionArea { get; set; } = null;
    }
}

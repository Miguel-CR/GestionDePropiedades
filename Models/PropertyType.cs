using System.ComponentModel.DataAnnotations;

namespace GestionDePropiedades.Models
{
    public class PropertyType
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "La descripción es requerida.")]
        [MaxLength(255, ErrorMessage = "La descripción debe de tener máximo 255 caracteres")]
        public string Description { get; set; }
    }
}

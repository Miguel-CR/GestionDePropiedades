using System.ComponentModel.DataAnnotations;

namespace GestionDePropiedades.Models
{
    public class Owner
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido.")]
        [MaxLength(255, ErrorMessage = "El nombre debe de tener máximo 255 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El teléfono es requerido.")]
        [MaxLength(255, ErrorMessage = "El teléfono debe de tener máximo 255 caracteres")]
        public string Telephone { get; set; }

        [EmailAddress(ErrorMessage = "El email no es válido.")]
        [MaxLength(255, ErrorMessage = "El Email debe de tener máximo 255 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El identificador del numero es requerido.")]
        [MaxLength(255, ErrorMessage = "El identificador del numero debe de tener máximo 255 caracteres")]
        public string IdentificationNumber { get; set; }

        [MaxLength(255, ErrorMessage = "La dirección debe de tener máximo 255 caracteres")]

        public string Address { get; set; }
    }
}

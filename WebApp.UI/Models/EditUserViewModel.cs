using System.ComponentModel.DataAnnotations;

namespace WebApp.UI.Models
{
    public class EditUserViewModel
    {
        [Required]
        public string Id { get; set; } = string.Empty;

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder 100 caracteres")]
        [Display(Name = "Nombre")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "El apellido es requerido")]
        [StringLength(100, ErrorMessage = "El apellido no puede exceder 100 caracteres")]
        [Display(Name = "Apellido")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "El correo electrónico es requerido")]
        [EmailAddress(ErrorMessage = "El formato del correo no es válido")]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; } = string.Empty;

        [Display(Name = "Usuario activo")]
        public bool IsActive { get; set; } = true;

        [Display(Name = "Roles asignados")]
        public List<string> Roles { get; set; } = new();
    }
}

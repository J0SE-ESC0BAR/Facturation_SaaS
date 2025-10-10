using System.ComponentModel.DataAnnotations;

namespace WebApp.UI.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "El correo electr�nico es requerido")]
        [EmailAddress(ErrorMessage = "El formato del correo electr�nico no es v�lido")]
        [Display(Name = "Correo electr�nico")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "La contrase�a es requerida")]
        [DataType(DataType.Password)]
        [Display(Name = "Contrase�a")]
        public string Password { get; set; } = string.Empty;

        [Display(Name = "Recordarme")]
        public bool RememberMe { get; set; }

        public string? ReturnUrl { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder 100 caracteres")]
        [Display(Name = "Nombre")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "El apellido es requerido")]
        [StringLength(100, ErrorMessage = "El apellido no puede exceder 100 caracteres")]
        [Display(Name = "Apellido")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "El correo electr�nico es requerido")]
        [EmailAddress(ErrorMessage = "El formato del correo electr�nico no es v�lido")]
        [Display(Name = "Correo electr�nico")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "La contrase�a es requerida")]
        [StringLength(100, ErrorMessage = "La {0} debe tener al menos {2} y m�ximo {1} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contrase�a")]
        public string Password { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contrase�a")]
        [Compare("Password", ErrorMessage = "La contrase�a y la confirmaci�n no coinciden")]
        public string ConfirmPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "Debe aceptar los t�rminos y condiciones")]
        [Display(Name = "Acepto los t�rminos y condiciones")]
        public bool AcceptTerms { get; set; }

        public string? ReturnUrl { get; set; }
    }

    public class UserInfoViewModel
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Provider { get; set; } = string.Empty;
        public DateTime LastLogin { get; set; }
        public string? ProfilePictureUrl { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "El correo electr�nico es requerido")]
        [EmailAddress(ErrorMessage = "El formato del correo electr�nico no es v�lido")]
        [Display(Name = "Correo electr�nico")]
        public string Email { get; set; } = string.Empty;
    }

    public class ResetPasswordViewModel
    {
        [Required]
        public string UserId { get; set; } = string.Empty;

        [Required]
        public string Token { get; set; } = string.Empty;

        [Required(ErrorMessage = "La contrase�a es requerida")]
        [StringLength(100, ErrorMessage = "La {0} debe tener al menos {2} y m�ximo {1} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nueva contrase�a")]
        public string Password { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar nueva contrase�a")]
        [Compare("Password", ErrorMessage = "La contrase�a y la confirmaci�n no coinciden")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }

    public class CompleteProfileViewModel
    {
        public string UserId { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder 100 caracteres")]
        [Display(Name = "Nombre")]
        public string FirstName { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "El apellido es requerido")]
        [StringLength(100, ErrorMessage = "El apellido no puede exceder 100 caracteres")]
        [Display(Name = "Apellido")]
        public string LastName { get; set; } = string.Empty;
        
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "El teléfono es requerido")]
        [Phone(ErrorMessage = "El formato del teléfono no es válido")]
        [Display(Name = "Teléfono")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha de nacimiento es requerida")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de nacimiento")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Imagen de perfil (URL)")]
        public string? ProfilePictureUrl { get; set; }

        // Datos de la empresa
        [Required(ErrorMessage = "El nombre de la empresa es requerido")]
        [StringLength(200, ErrorMessage = "El nombre de la empresa no puede exceder 200 caracteres")]
        [Display(Name = "Nombre de la empresa")]
        public string CompanyName { get; set; } = string.Empty;

        [Required(ErrorMessage = "El RNC es requerido")]
        [StringLength(11, MinimumLength = 9, ErrorMessage = "El RNC debe tener entre 9 y 11 caracteres")]
        [Display(Name = "RNC")]
        public string CompanyRNC { get; set; } = string.Empty;

        [Required(ErrorMessage = "La dirección de la empresa es requerida")]
        [StringLength(500, ErrorMessage = "La dirección no puede exceder 500 caracteres")]
        [Display(Name = "Dirección de la empresa")]
        public string CompanyAddress { get; set; } = string.Empty;

        [Required(ErrorMessage = "El teléfono de la empresa es requerido")]
        [Phone(ErrorMessage = "El formato del teléfono no es válido")]
        [Display(Name = "Teléfono de la empresa")]
        public string CompanyPhone { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido")]
        [Display(Name = "Email de la empresa")]
        public string? CompanyEmail { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un rol")]
        [Display(Name = "Rol en la empresa")]
        public string Role { get; set; } = string.Empty;

        public string? ReturnUrl { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace WebApp.UI.Models
{
    public class CompanyViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la empresa es requerido")]
        [StringLength(200, ErrorMessage = "El nombre no puede exceder 200 caracteres")]
        [Display(Name = "Nombre de la empresa")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "El RNC es requerido")]
        [StringLength(11, ErrorMessage = "El RNC debe tener 9 u 11 caracteres", MinimumLength = 9)]
        [Display(Name = "RNC")]
        public string TaxId { get; set; } = string.Empty;

        [Required(ErrorMessage = "El teléfono es requerido")]
        [Phone(ErrorMessage = "El formato del teléfono no es válido")]
        [Display(Name = "Teléfono")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "El correo electrónico es requerido")]
        [EmailAddress(ErrorMessage = "El formato del correo no es válido")]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "La dirección es requerida")]
        [StringLength(500, ErrorMessage = "La dirección no puede exceder 500 caracteres")]
        [Display(Name = "Dirección")]
        public string Address { get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = "La ciudad no puede exceder 100 caracteres")]
        [Display(Name = "Ciudad")]
        public string? City { get; set; }

        [StringLength(100, ErrorMessage = "La provincia no puede exceder 100 caracteres")]
        [Display(Name = "Provincia")]
        public string? State { get; set; }

        [StringLength(10, ErrorMessage = "El código postal no puede exceder 10 caracteres")]
        [Display(Name = "Código postal")]
        public string? ZipCode { get; set; }

        [Display(Name = "País")]
        public string Country { get; set; } = "República Dominicana";

        [Url(ErrorMessage = "El formato de la URL no es válido")]
        [Display(Name = "Sitio web")]
        public string? Website { get; set; }

        [Display(Name = "Logo de la empresa")]
        public string? LogoUrl { get; set; }

        [Display(Name = "Empresa activa")]
        public bool IsActive { get; set; } = true;

        // Configuración fiscal
        [Display(Name = "Número de certificado DGII")]
        public string? DGIICertificateNumber { get; set; }

        [Display(Name = "Usuario DGII")]
        public string? DGIIUsername { get; set; }

        [Display(Name = "Contraseña DGII")]
        [DataType(DataType.Password)]
        public string? DGIIPassword { get; set; }

        [Display(Name = "Ambiente DGII")]
        public string DGIIEnvironment { get; set; } = "Test"; // Test o Production

        [Display(Name = "Fecha de creación")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

    public class CompanyListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string TaxId { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public int UsersCount { get; set; }
        public int InvoicesCount { get; set; }
    }
}
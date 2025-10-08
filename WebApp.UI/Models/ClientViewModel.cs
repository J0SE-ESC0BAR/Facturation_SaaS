using System.ComponentModel.DataAnnotations;

namespace WebApp.UI.Models
{
    public class ClientViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(200, ErrorMessage = "El nombre no puede exceder 200 caracteres")]
        [Display(Name = "Nombre o razón social")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Nombre comercial")]
        [StringLength(200, ErrorMessage = "El nombre comercial no puede exceder 200 caracteres")]
        public string? CommercialName { get; set; }

        [Required(ErrorMessage = "El tipo de identificación es requerido")]
        [Display(Name = "Tipo de identificación")]
        public string IdentificationType { get; set; } = "RNC"; // RNC, Cédula, Pasaporte

        [Required(ErrorMessage = "El número de identificación es requerido")]
        [StringLength(20, ErrorMessage = "La identificación no puede exceder 20 caracteres")]
        [Display(Name = "RNC/Cédula/Pasaporte")]
        public string TaxId { get; set; } = string.Empty;

        [Required(ErrorMessage = "El correo electrónico es requerido")]
        [EmailAddress(ErrorMessage = "El formato del correo no es válido")]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; } = string.Empty;

        [Phone(ErrorMessage = "El formato del teléfono no es válido")]
        [Display(Name = "Teléfono principal")]
        public string? Phone { get; set; }

        [Phone(ErrorMessage = "El formato del teléfono no es válido")]
        [Display(Name = "Teléfono secundario")]
        public string? Phone2 { get; set; }

        [StringLength(500, ErrorMessage = "La dirección no puede exceder 500 caracteres")]
        [Display(Name = "Dirección")]
        public string? Address { get; set; }

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

        [Display(Name = "Tipo de cliente")]
        public string ClientType { get; set; } = "General"; // General, Empresa, VIP

        [Display(Name = "Persona de contacto")]
        [StringLength(200, ErrorMessage = "El nombre de contacto no puede exceder 200 caracteres")]
        public string? ContactPerson { get; set; }

        [Display(Name = "Límite de crédito")]
        [Range(0, double.MaxValue, ErrorMessage = "El límite de crédito debe ser positivo")]
        public decimal CreditLimit { get; set; }

        [Display(Name = "Días de crédito")]
        [Range(0, 365, ErrorMessage = "Los días de crédito deben estar entre 0 y 365")]
        public int CreditDays { get; set; } = 30;

        [Display(Name = "Notas")]
        [StringLength(1000, ErrorMessage = "Las notas no pueden exceder 1000 caracteres")]
        public string? Notes { get; set; }

        [Display(Name = "Cliente activo")]
        public bool IsActive { get; set; } = true;

        [Display(Name = "Empresa")]
        public int CompanyId { get; set; }

        [Display(Name = "Fecha de creación")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Propiedades de solo lectura
        public decimal TotalInvoiced { get; set; }
        public decimal TotalPaid { get; set; }
        public decimal Balance { get; set; }
        public int InvoicesCount { get; set; }
    }

    public class ClientListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string TaxId { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public decimal Balance { get; set; }
        public int InvoicesCount { get; set; }
        public bool IsActive { get; set; }
    }
}

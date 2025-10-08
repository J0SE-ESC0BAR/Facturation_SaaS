using System.ComponentModel.DataAnnotations;

namespace WebApp.UI.Models
{
    public class ProfileViewModel
    {
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

        [Phone(ErrorMessage = "El formato del teléfono no es válido")]
        [Display(Name = "Teléfono")]
        public string? Phone { get; set; }

        [Display(Name = "Foto de perfil")]
        public string? ProfilePictureUrl { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "La contraseña actual es requerida")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña actual")]
        public string CurrentPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "La nueva contraseña es requerida")]
        [StringLength(100, ErrorMessage = "La {0} debe tener al menos {2} y máximo {1} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nueva contraseña")]
        public string NewPassword { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar nueva contraseña")]
        [Compare("NewPassword", ErrorMessage = "La nueva contraseña y la confirmación no coinciden")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }

    public class InvoiceTemplateViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la plantilla es requerido")]
        [Display(Name = "Nombre de la plantilla")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Plantilla por defecto")]
        public bool IsDefault { get; set; }

        [Display(Name = "Color primario")]
        public string PrimaryColor { get; set; } = "#007bff";

        [Display(Name = "Color secundario")]
        public string SecondaryColor { get; set; } = "#6c757d";

        [Display(Name = "Mostrar logo")]
        public bool ShowLogo { get; set; } = true;

        [Display(Name = "Mostrar firma")]
        public bool ShowSignature { get; set; }

        [Display(Name = "Texto del pie de página")]
        [StringLength(500)]
        public string? FooterText { get; set; }

        [Display(Name = "Diseño")]
        public string Layout { get; set; } = "Standard"; // Standard, Modern, Classic

        public int CompanyId { get; set; }
    }

    public class NotificationSettingsViewModel
    {
        [Display(Name = "Notificaciones por email")]
        public bool EmailNotifications { get; set; } = true;

        [Display(Name = "Notificar nuevas facturas")]
        public bool NotifyNewInvoice { get; set; } = true;

        [Display(Name = "Notificar pagos recibidos")]
        public bool NotifyPayment { get; set; } = true;

        [Display(Name = "Notificar facturas vencidas")]
        public bool NotifyOverdueInvoice { get; set; } = true;

        [Display(Name = "Notificaciones push")]
        public bool PushNotifications { get; set; }

        [Display(Name = "Resumen diario")]
        public bool DailySummary { get; set; }

        [Display(Name = "Resumen semanal")]
        public bool WeeklySummary { get; set; }
    }

    public class FiscalConfigViewModel
    {
        [Required(ErrorMessage = "El número de certificado DGII es requerido")]
        [Display(Name = "Número de certificado DGII")]
        public string CertificateNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "El usuario DGII es requerido")]
        [Display(Name = "Usuario DGII")]
        public string DGIIUsername { get; set; } = string.Empty;

        [Required(ErrorMessage = "La contraseña DGII es requerida")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña DGII")]
        public string DGIIPassword { get; set; } = string.Empty;

        [Display(Name = "Ambiente")]
        public string Environment { get; set; } = "Test"; // Test, Production

        [Display(Name = "Secuencia NCF activa")]
        public string? CurrentNCFSequence { get; set; }

        [Display(Name = "Prefijo de factura")]
        public string InvoicePrefix { get; set; } = "FAC";

        [Display(Name = "Siguiente número de factura")]
        [Range(1, int.MaxValue)]
        public int NextInvoiceNumber { get; set; } = 1;

        [Display(Name = "Activar firma digital")]
        public bool EnableDigitalSignature { get; set; }

        [Display(Name = "Archivo de certificado (.p12)")]
        public string? CertificateFile { get; set; }

        public int CompanyId { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace WebApp.UI.Models
{
    public class PaymentViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una factura")]
        [Display(Name = "Factura")]
        public int InvoiceId { get; set; }

        public string? InvoiceNumber { get; set; }
        public string? ClientName { get; set; }

        [Required(ErrorMessage = "La fecha de pago es requerida")]
        [Display(Name = "Fecha de pago")]
        public DateTime PaymentDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "El monto es requerido")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor a 0")]
        [Display(Name = "Monto pagado")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Debe seleccionar el método de pago")]
        [Display(Name = "Método de pago")]
        public string PaymentMethod { get; set; } = "Efectivo"; // Efectivo, Transferencia, Cheque, Tarjeta, PayPal, Wompi

        [Display(Name = "Número de referencia")]
        [StringLength(100, ErrorMessage = "La referencia no puede exceder 100 caracteres")]
        public string? ReferenceNumber { get; set; }

        [Display(Name = "Banco")]
        [StringLength(100, ErrorMessage = "El banco no puede exceder 100 caracteres")]
        public string? BankName { get; set; }

        [Display(Name = "Número de cuenta")]
        [StringLength(50, ErrorMessage = "El número de cuenta no puede exceder 50 caracteres")]
        public string? AccountNumber { get; set; }

        [Display(Name = "Notas")]
        [StringLength(500, ErrorMessage = "Las notas no pueden exceder 500 caracteres")]
        public string? Notes { get; set; }

        [Display(Name = "Estado")]
        public string Status { get; set; } = "Completado"; // Pendiente, Completado, Rechazado

        [Display(Name = "Comprobante de pago")]
        public string? ReceiptUrl { get; set; }

        [Display(Name = "Empresa")]
        public int CompanyId { get; set; }

        [Display(Name = "Registrado por")]
        public string? CreatedBy { get; set; }

        [Display(Name = "Fecha de registro")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

    public class OnlinePaymentViewModel
    {
        [Required]
        public int InvoiceId { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Amount { get; set; }

        [Required]
        public string PaymentGateway { get; set; } = "PayPal"; // PayPal, Wompi, N1co

        public string? ReturnUrl { get; set; }
        public string? CancelUrl { get; set; }
    }

    public class PaymentListViewModel
    {
        public int Id { get; set; }
        public string InvoiceNumber { get; set; } = string.Empty;
        public string ClientName { get; set; } = string.Empty;
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public string? ReferenceNumber { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}

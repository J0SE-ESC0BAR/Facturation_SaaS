using System.ComponentModel.DataAnnotations;

namespace WebApp.UI.Models
{
    /// <summary>
    /// Modelo para representar un pago aplicado a una o más facturas
    /// </summary>
    public class Payment
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// ID de la empresa que recibe el pago
        /// </summary>
        [Required]
        public int CompanyId { get; set; }

        /// <summary>
        /// ID del cliente que realiza el pago
        /// </summary>
        [Required]
        public int ClientId { get; set; }

        /// <summary>
        /// ID de la factura principal (si el pago es para una sola factura)
        /// </summary>
        public int? InvoiceId { get; set; }

        /// <summary>
        /// Número de recibo del pago
        /// </summary>
        [Required]
        [StringLength(50)]
        public string ReceiptNumber { get; set; } = string.Empty;

        /// <summary>
        /// Fecha del pago
        /// </summary>
        [Required]
        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Monto del pago
        /// </summary>
        [Required]
        public decimal Amount { get; set; }

        /// <summary>
        /// Método de pago: Cash, CreditCard, DebitCard, Transfer, Check, Other
        /// </summary>
        [Required]
        [StringLength(50)]
        public string PaymentMethod { get; set; } = "Cash";

        /// <summary>
        /// Número de referencia (cheque, transferencia, etc.)
        /// </summary>
        [StringLength(100)]
        public string? ReferenceNumber { get; set; }

        /// <summary>
        /// Banco (si aplica)
        /// </summary>
        [StringLength(100)]
        public string? Bank { get; set; }

        /// <summary>
        /// Notas adicionales sobre el pago
        /// </summary>
        public string? Notes { get; set; }

        /// <summary>
        /// Estado del pago: Pending, Completed, Cancelled
        /// </summary>
        [Required]
        [StringLength(20)]
        public string Status { get; set; } = "Completed";

        /// <summary>
        /// Fecha de creación
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// ID del usuario que registró el pago
        /// </summary>
        [Required]
        [StringLength(450)]
        public string CreatedByUserId { get; set; } = string.Empty;

        /// <summary>
        /// Fecha de última actualización
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        // Relaciones de navegación

        /// <summary>
        /// Empresa que recibe el pago
        /// </summary>
        public virtual Company? Company { get; set; }

        /// <summary>
        /// Cliente que realiza el pago
        /// </summary>
        public virtual Client? Client { get; set; }

        /// <summary>
        /// Factura principal asociada
        /// </summary>
        public virtual Invoice? Invoice { get; set; }

        /// <summary>
        /// Usuario que registró el pago
        /// </summary>
        public virtual ApplicationUser? CreatedBy { get; set; }
    }
}

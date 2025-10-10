using System.ComponentModel.DataAnnotations;

namespace WebApp.UI.Models
{
    /// <summary>
    /// Modelo para representar una factura (NCF)
    /// Cada factura pertenece a una empresa y es emitida por un usuario facturador
    /// </summary>
    public class Invoice
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// ID de la empresa que emite la factura
        /// </summary>
        [Required]
        public int CompanyId { get; set; }

        /// <summary>
        /// ID del cliente al que se le emite la factura
        /// </summary>
        [Required]
        public int ClientId { get; set; }

        /// <summary>
        /// Número de factura (secuencial)
        /// </summary>
        [Required]
        [StringLength(50)]
        public string InvoiceNumber { get; set; } = string.Empty;

        /// <summary>
        /// NCF (Número de Comprobante Fiscal)
        /// </summary>
        [StringLength(50)]
        public string? NCF { get; set; }

        /// <summary>
        /// Tipo de NCF: B01 (Crédito Fiscal), B02 (Consumo), B14 (Régimen Especial), B15 (Gubernamental)
        /// </summary>
        [StringLength(10)]
        public string? NCFType { get; set; }

        /// <summary>
        /// Serie de la factura
        /// </summary>
        [StringLength(10)]
        public string? Series { get; set; }

        /// <summary>
        /// Fecha de emisión de la factura
        /// </summary>
        [Required]
        public DateTime IssueDate { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Fecha de vencimiento de pago
        /// </summary>
        public DateTime? DueDate { get; set; }

        /// <summary>
        /// Estado de la factura: Draft, Pending, Sent, Paid, Cancelled, Overdue
        /// </summary>
        [Required]
        [StringLength(20)]
        public string Status { get; set; } = "Draft";

        /// <summary>
        /// Subtotal (sin impuestos)
        /// </summary>
        [Required]
        public decimal Subtotal { get; set; }

        /// <summary>
        /// Total de impuestos (ITBIS)
        /// </summary>
        [Required]
        public decimal TaxAmount { get; set; }

        /// <summary>
        /// Descuento aplicado
        /// </summary>
        public decimal DiscountAmount { get; set; }

        /// <summary>
        /// Total de la factura
        /// </summary>
        [Required]
        public decimal Total { get; set; }

        /// <summary>
        /// Total pagado hasta el momento
        /// </summary>
        public decimal AmountPaid { get; set; }

        /// <summary>
        /// Balance pendiente
        /// </summary>
        public decimal Balance { get; set; }

        /// <summary>
        /// Método de pago: Cash, CreditCard, Transfer, Check
        /// </summary>
        [StringLength(50)]
        public string? PaymentMethod { get; set; }

        /// <summary>
        /// Términos de pago
        /// </summary>
        [StringLength(100)]
        public string? PaymentTerms { get; set; }

        /// <summary>
        /// Notas o comentarios adicionales
        /// </summary>
        public string? Notes { get; set; }

        /// <summary>
        /// Términos y condiciones
        /// </summary>
        public string? TermsAndConditions { get; set; }

        /// <summary>
        /// Indica si la factura fue enviada a DGII
        /// </summary>
        public bool SentToDGII { get; set; }

        /// <summary>
        /// Fecha de envío a DGII
        /// </summary>
        public DateTime? SentToDGIIDate { get; set; }

        /// <summary>
        /// Código de autorización de DGII
        /// </summary>
        [StringLength(100)]
        public string? DGIIAuthorizationCode { get; set; }

        /// <summary>
        /// Respuesta de DGII (XML o JSON)
        /// </summary>
        public string? DGIIResponse { get; set; }

        /// <summary>
        /// Fecha de creación
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// ID del usuario que creó la factura (facturador)
        /// </summary>
        [Required]
        [StringLength(450)]
        public string CreatedByUserId { get; set; } = string.Empty;

        /// <summary>
        /// Fecha de última actualización
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// ID del usuario que actualizó la factura
        /// </summary>
        [StringLength(450)]
        public string? UpdatedByUserId { get; set; }

        // Relaciones de navegación

        /// <summary>
        /// Empresa que emite la factura
        /// </summary>
        public virtual Company? Company { get; set; }

        /// <summary>
        /// Cliente al que se le emite la factura
        /// </summary>
        public virtual Client? Client { get; set; }

        /// <summary>
        /// Usuario que creó la factura (facturador)
        /// </summary>
        public virtual ApplicationUser? CreatedBy { get; set; }

        /// <summary>
        /// Usuario que actualizó la factura
        /// </summary>
        public virtual ApplicationUser? UpdatedBy { get; set; }

        /// <summary>
        /// Líneas de detalle de la factura (productos/servicios)
        /// </summary>
        public virtual ICollection<InvoiceLine> InvoiceLines { get; set; } = new List<InvoiceLine>();

        /// <summary>
        /// Pagos aplicados a esta factura
        /// </summary>
        public virtual ICollection<Payment>? Payments { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace WebApp.UI.Models
{
    public class CreditNoteViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe seleccionar la factura original")]
        [Display(Name = "Factura original")]
        public int OriginalInvoiceId { get; set; }

        public string? OriginalInvoiceNumber { get; set; }

        [Required(ErrorMessage = "El número de nota de crédito es requerido")]
        [Display(Name = "Número de nota de crédito")]
        public string CreditNoteNumber { get; set; } = string.Empty;

        [Display(Name = "NCF")]
        public string? NCF { get; set; }

        [Required(ErrorMessage = "La fecha es requerida")]
        [Display(Name = "Fecha de emisión")]
        public DateTime IssueDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Debe especificar el motivo")]
        [StringLength(500, ErrorMessage = "El motivo no puede exceder 500 caracteres")]
        [Display(Name = "Motivo de la nota de crédito")]
        public string Reason { get; set; } = string.Empty;

        [Required(ErrorMessage = "El monto es requerido")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor a 0")]
        [Display(Name = "Monto")]
        public decimal Amount { get; set; }

        [Display(Name = "ITBIS")]
        public decimal TaxAmount { get; set; }

        [Display(Name = "Total")]
        public decimal Total { get; set; }

        [Display(Name = "Estado")]
        public string Status { get; set; } = "Borrador";

        [Display(Name = "Fecha de envío a DGII")]
        public DateTime? SentToDGIIAt { get; set; }

        [Display(Name = "Empresa")]
        public int CompanyId { get; set; }

        [Display(Name = "Creado por")]
        public string? CreatedBy { get; set; }

        [Display(Name = "Fecha de creación")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

    public class DebitNoteViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe seleccionar la factura original")]
        [Display(Name = "Factura original")]
        public int OriginalInvoiceId { get; set; }

        public string? OriginalInvoiceNumber { get; set; }

        [Required(ErrorMessage = "El número de nota de débito es requerido")]
        [Display(Name = "Número de nota de débito")]
        public string DebitNoteNumber { get; set; } = string.Empty;

        [Display(Name = "NCF")]
        public string? NCF { get; set; }

        [Required(ErrorMessage = "La fecha es requerida")]
        [Display(Name = "Fecha de emisión")]
        public DateTime IssueDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Debe especificar el motivo")]
        [StringLength(500, ErrorMessage = "El motivo no puede exceder 500 caracteres")]
        [Display(Name = "Motivo de la nota de débito")]
        public string Reason { get; set; } = string.Empty;

        [Required(ErrorMessage = "El monto es requerido")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor a 0")]
        [Display(Name = "Monto adicional")]
        public decimal Amount { get; set; }

        [Display(Name = "ITBIS")]
        public decimal TaxAmount { get; set; }

        [Display(Name = "Total")]
        public decimal Total { get; set; }

        [Display(Name = "Estado")]
        public string Status { get; set; } = "Borrador";

        [Display(Name = "Fecha de envío a DGII")]
        public DateTime? SentToDGIIAt { get; set; }

        [Display(Name = "Empresa")]
        public int CompanyId { get; set; }

        [Display(Name = "Creado por")]
        public string? CreatedBy { get; set; }

        [Display(Name = "Fecha de creación")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
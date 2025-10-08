using System.ComponentModel.DataAnnotations;

namespace WebApp.UI.Models
{
    public class InvoiceViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El número de factura es requerido")]
        [Display(Name = "Número de factura")]
        public string InvoiceNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Debe seleccionar un cliente")]
        [Display(Name = "Cliente")]
        public int ClientId { get; set; }

        public string? ClientName { get; set; }

        [Required(ErrorMessage = "La fecha es requerida")]
        [Display(Name = "Fecha de emisión")]
        public DateTime IssueDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "La fecha de vencimiento es requerida")]
        [Display(Name = "Fecha de vencimiento")]
        public DateTime DueDate { get; set; } = DateTime.Now.AddDays(30);

        [Display(Name = "Estado")]
        public string Status { get; set; } = "Borrador"; // Borrador, Enviada, Pagada, Vencida, Cancelada

        [Display(Name = "Tipo de comprobante")]
        public string DocumentType { get; set; } = "Factura"; // Factura, Nota de Crédito, Nota de Débito

        [Display(Name = "NCF (Número de Comprobante Fiscal)")]
        public string? NCF { get; set; }

        [Display(Name = "Secuencia NCF")]
        public string? NCFSequence { get; set; }

        [Display(Name = "Items de la factura")]
        public List<InvoiceItemViewModel> Items { get; set; } = new();

        [Display(Name = "Subtotal")]
        public decimal Subtotal { get; set; }

        [Display(Name = "ITBIS (18%)")]
        public decimal TaxAmount { get; set; }

        [Display(Name = "Descuento")]
        public decimal Discount { get; set; }

        [Display(Name = "Total")]
        public decimal Total { get; set; }

        [Display(Name = "Total pagado")]
        public decimal AmountPaid { get; set; }

        [Display(Name = "Saldo pendiente")]
        public decimal Balance { get; set; }

        [StringLength(1000, ErrorMessage = "Las notas no pueden exceder 1000 caracteres")]
        [Display(Name = "Notas")]
        public string? Notes { get; set; }

        [StringLength(500, ErrorMessage = "Los términos no pueden exceder 500 caracteres")]
        [Display(Name = "Términos y condiciones")]
        public string? Terms { get; set; }

        [Display(Name = "Fecha de envío a DGII")]
        public DateTime? SentToDGIIAt { get; set; }

        [Display(Name = "Estado DGII")]
        public string? DGIIStatus { get; set; }

        [Display(Name = "Respuesta DGII")]
        public string? DGIIResponse { get; set; }

        [Display(Name = "Empresa")]
        public int CompanyId { get; set; }

        [Display(Name = "Creado por")]
        public string? CreatedBy { get; set; }

        [Display(Name = "Fecha de creación")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

    public class InvoiceItemViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un producto")]
        [Display(Name = "Producto/Servicio")]
        public int ProductId { get; set; }

        public string? ProductName { get; set; }

        [StringLength(500, ErrorMessage = "La descripción no puede exceder 500 caracteres")]
        [Display(Name = "Descripción")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "La cantidad es requerida")]
        [Range(0.01, double.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0")]
        [Display(Name = "Cantidad")]
        public decimal Quantity { get; set; } = 1;

        [Required(ErrorMessage = "El precio unitario es requerido")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0")]
        [Display(Name = "Precio unitario")]
        public decimal UnitPrice { get; set; }

        [Display(Name = "Aplicar ITBIS")]
        public bool ApplyTax { get; set; } = true;

        [Display(Name = "% Descuento")]
        [Range(0, 100, ErrorMessage = "El descuento debe estar entre 0 y 100")]
        public decimal DiscountPercent { get; set; }

        [Display(Name = "Subtotal")]
        public decimal Subtotal { get; set; }

        [Display(Name = "ITBIS")]
        public decimal TaxAmount { get; set; }

        [Display(Name = "Total")]
        public decimal Total { get; set; }
    }

    public class InvoiceListViewModel
    {
        public int Id { get; set; }
        public string InvoiceNumber { get; set; } = string.Empty;
        public string ClientName { get; set; } = string.Empty;
        public DateTime IssueDate { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Total { get; set; }
        public decimal Balance { get; set; }
        public string Status { get; set; } = string.Empty;
        public string? NCF { get; set; }
        public string? DGIIStatus { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace WebApp.UI.Models
{
    /// <summary>
    /// Modelo para representar una línea de detalle en una factura
    /// Cada línea representa un producto o servicio facturado
    /// </summary>
    public class InvoiceLine
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// ID de la factura a la que pertenece esta línea
        /// </summary>
        [Required]
        public int InvoiceId { get; set; }

        /// <summary>
        /// ID del producto o servicio
        /// </summary>
        public int? ProductId { get; set; }

        /// <summary>
        /// Número de línea (orden)
        /// </summary>
        [Required]
        public int LineNumber { get; set; }

        /// <summary>
        /// Descripción del producto/servicio
        /// Puede ser diferente al nombre del producto
        /// </summary>
        [Required]
        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Cantidad
        /// </summary>
        [Required]
        public decimal Quantity { get; set; }

        /// <summary>
        /// Unidad de medida
        /// </summary>
        [StringLength(50)]
        public string Unit { get; set; } = "Unidad";

        /// <summary>
        /// Precio unitario sin impuestos
        /// </summary>
        [Required]
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Subtotal de la línea (Quantity * UnitPrice)
        /// </summary>
        [Required]
        public decimal Subtotal { get; set; }

        /// <summary>
        /// Porcentaje de descuento aplicado
        /// </summary>
        public decimal DiscountPercentage { get; set; }

        /// <summary>
        /// Monto de descuento
        /// </summary>
        public decimal DiscountAmount { get; set; }

        /// <summary>
        /// Subtotal después de descuento
        /// </summary>
        public decimal SubtotalAfterDiscount { get; set; }

        /// <summary>
        /// Porcentaje de ITBIS aplicado
        /// </summary>
        public decimal TaxRate { get; set; }

        /// <summary>
        /// Monto de ITBIS
        /// </summary>
        public decimal TaxAmount { get; set; }

        /// <summary>
        /// Total de la línea (incluye impuestos)
        /// </summary>
        [Required]
        public decimal Total { get; set; }

        // Relaciones de navegación

        /// <summary>
        /// Factura a la que pertenece esta línea
        /// </summary>
        public virtual Invoice? Invoice { get; set; }

        /// <summary>
        /// Producto asociado (opcional, puede ser un servicio sin producto)
        /// </summary>
        public virtual Product? Product { get; set; }
    }
}

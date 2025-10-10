using System.ComponentModel.DataAnnotations;

namespace WebApp.UI.Models
{
    /// <summary>
    /// Modelo para representar un producto o servicio
    /// Cada producto pertenece a una empresa específica
    /// </summary>
    public class Product
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// ID de la empresa a la que pertenece este producto
        /// </summary>
        [Required]
        public int CompanyId { get; set; }

        /// <summary>
        /// Código único del producto (SKU)
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Code { get; set; } = string.Empty;

        /// <summary>
        /// Nombre del producto o servicio
        /// </summary>
        [Required]
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Descripción detallada
        /// </summary>
        [StringLength(1000)]
        public string? Description { get; set; }

        /// <summary>
        /// Categoría del producto
        /// </summary>
        [StringLength(100)]
        public string? Category { get; set; }

        /// <summary>
        /// Tipo: Product o Service
        /// </summary>
        [Required]
        [StringLength(20)]
        public string Type { get; set; } = "Product";

        /// <summary>
        /// Unidad de medida: Unidad, Caja, Kg, etc.
        /// </summary>
        [StringLength(50)]
        public string Unit { get; set; } = "Unidad";

        /// <summary>
        /// Precio unitario sin impuestos
        /// </summary>
        [Required]
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Costo del producto (para cálculo de margen)
        /// </summary>
        public decimal Cost { get; set; }

        /// <summary>
        /// Porcentaje de ITBIS (18% estándar en RD)
        /// </summary>
        public decimal TaxRate { get; set; } = 18m;

        /// <summary>
        /// Indica si el producto aplica ITBIS
        /// </summary>
        public bool IsTaxable { get; set; } = true;

        /// <summary>
        /// Stock actual del producto
        /// </summary>
        public decimal Stock { get; set; }

        /// <summary>
        /// Stock mínimo (alerta de reorden)
        /// </summary>
        public decimal MinimumStock { get; set; }

        /// <summary>
        /// Indica si se controla inventario
        /// </summary>
        public bool TrackInventory { get; set; } = true;

        /// <summary>
        /// Indica si el producto está activo
        /// </summary>
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// URL de la imagen del producto
        /// </summary>
        public string? ImageUrl { get; set; }

        /// <summary>
        /// Código de barras
        /// </summary>
        [StringLength(50)]
        public string? Barcode { get; set; }

        /// <summary>
        /// Fecha de creación
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// ID del usuario que creó el producto
        /// </summary>
        [StringLength(450)]
        public string? CreatedByUserId { get; set; }

        /// <summary>
        /// Fecha de última actualización
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        // Relaciones de navegación

        /// <summary>
        /// Empresa a la que pertenece este producto
        /// </summary>
        public virtual Company? Company { get; set; }

        /// <summary>
        /// Usuario que creó el producto
        /// </summary>
        public virtual ApplicationUser? CreatedBy { get; set; }

        /// <summary>
        /// Líneas de factura que incluyen este producto
        /// </summary>
        public virtual ICollection<InvoiceLine>? InvoiceLines { get; set; }
    }
}

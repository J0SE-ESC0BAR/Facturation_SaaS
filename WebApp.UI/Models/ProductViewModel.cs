using System.ComponentModel.DataAnnotations;

namespace WebApp.UI.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El código del producto es requerido")]
        [StringLength(50, ErrorMessage = "El código no puede exceder 50 caracteres")]
        [Display(Name = "Código/SKU")]
        public string Code { get; set; } = string.Empty;

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(200, ErrorMessage = "El nombre no puede exceder 200 caracteres")]
        [Display(Name = "Nombre")]
        public string Name { get; set; } = string.Empty;

        [StringLength(1000, ErrorMessage = "La descripción no puede exceder 1000 caracteres")]
        [Display(Name = "Descripción")]
        public string? Description { get; set; }

        [Display(Name = "Tipo")]
        public string Type { get; set; } = "Producto"; // Producto, Servicio

        [Display(Name = "Categoría")]
        [StringLength(100, ErrorMessage = "La categoría no puede exceder 100 caracteres")]
        public string? Category { get; set; }

        [Required(ErrorMessage = "El precio es requerido")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0")]
        [Display(Name = "Precio de venta")]
        public decimal Price { get; set; }

        [Display(Name = "Precio de costo")]
        [Range(0, double.MaxValue, ErrorMessage = "El costo debe ser positivo")]
        public decimal Cost { get; set; }

        [Display(Name = "Aplicar ITBIS (18%)")]
        public bool IsTaxable { get; set; } = true;

        [Display(Name = "% ITBIS")]
        [Range(0, 100, ErrorMessage = "El porcentaje debe estar entre 0 y 100")]
        public decimal TaxRate { get; set; } = 18;

        [Display(Name = "Unidad de medida")]
        [StringLength(20, ErrorMessage = "La unidad no puede exceder 20 caracteres")]
        public string Unit { get; set; } = "Unidad"; // Unidad, Caja, Kg, Litro, Hora, etc.

        [Display(Name = "Stock actual")]
        public int Stock { get; set; }

        [Display(Name = "Stock mínimo")]
        public int MinStock { get; set; }

        [Display(Name = "Controlar inventario")]
        public bool TrackInventory { get; set; }

        [Display(Name = "Código de barras")]
        [StringLength(50, ErrorMessage = "El código de barras no puede exceder 50 caracteres")]
        public string? Barcode { get; set; }

        [Display(Name = "Imagen del producto")]
        public string? ImageUrl { get; set; }

        [Display(Name = "Producto activo")]
        public bool IsActive { get; set; } = true;

        [Display(Name = "Empresa")]
        public int CompanyId { get; set; }

        [Display(Name = "Fecha de creación")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

    public class ProductListViewModel
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string? Category { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public bool IsActive { get; set; }
    }
}

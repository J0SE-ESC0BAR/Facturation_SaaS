using System.ComponentModel.DataAnnotations;

namespace WebApp.UI.Models
{
    /// <summary>
    /// Modelo para representar un cliente
    /// Cada cliente pertenece a una empresa específica
    /// </summary>
    public class Client
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// ID de la empresa a la que pertenece este cliente
        /// </summary>
        [Required]
        public int CompanyId { get; set; }

        /// <summary>
        /// Nombre o razón social del cliente
        /// </summary>
        [Required]
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// RNC o Cédula del cliente
        /// </summary>
        [Required]
        [StringLength(20)]
        public string TaxId { get; set; } = string.Empty;

        /// <summary>
        /// Tipo de identificación: RNC, Cédula, Pasaporte
        /// </summary>
        [StringLength(20)]
        public string IdType { get; set; } = "RNC";

        /// <summary>
        /// Email del cliente
        /// </summary>
        [EmailAddress]
        [StringLength(100)]
        public string? Email { get; set; }

        /// <summary>
        /// Teléfono del cliente
        /// </summary>
        [Phone]
        [StringLength(20)]
        public string? Phone { get; set; }

        /// <summary>
        /// Dirección del cliente
        /// </summary>
        [StringLength(500)]
        public string? Address { get; set; }

        /// <summary>
        /// Ciudad
        /// </summary>
        [StringLength(100)]
        public string? City { get; set; }

        /// <summary>
        /// Provincia/Estado
        /// </summary>
        [StringLength(100)]
        public string? State { get; set; }

        /// <summary>
        /// País
        /// </summary>
        [StringLength(100)]
        public string Country { get; set; } = "República Dominicana";

        /// <summary>
        /// Tipo de cliente: Regular, VIP, Wholesale
        /// </summary>
        [StringLength(50)]
        public string? CustomerType { get; set; }

        /// <summary>
        /// Límite de crédito para el cliente
        /// </summary>
        public decimal CreditLimit { get; set; }

        /// <summary>
        /// Balance actual del cliente
        /// </summary>
        public decimal Balance { get; set; }

        /// <summary>
        /// Indica si el cliente está activo
        /// </summary>
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Notas adicionales sobre el cliente
        /// </summary>
        public string? Notes { get; set; }

        /// <summary>
        /// Fecha de creación
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// ID del usuario que creó el cliente
        /// </summary>
        [StringLength(450)]
        public string? CreatedByUserId { get; set; }

        /// <summary>
        /// Fecha de última actualización
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        // Relaciones de navegación

        /// <summary>
        /// Empresa a la que pertenece este cliente
        /// </summary>
        public virtual Company? Company { get; set; }

        /// <summary>
        /// Usuario que creó el cliente
        /// </summary>
        public virtual ApplicationUser? CreatedBy { get; set; }

        /// <summary>
        /// Facturas emitidas a este cliente
        /// </summary>
        public virtual ICollection<Invoice>? Invoices { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.UI.Models
{
    /// <summary>
    /// Relación Muchos a Muchos entre Usuarios y Empresas
    /// Permite que un usuario pertenezca a múltiples empresas con diferentes roles
    /// </summary>
    public class UserCompany
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// ID del usuario
        /// </summary>
        [Required]
        public string UserId { get; set; } = string.Empty;

        /// <summary>
        /// ID de la empresa
        /// </summary>
        [Required]
        public int CompanyId { get; set; }

        /// <summary>
        /// Rol del usuario en esta empresa específica
        /// Permite que un usuario tenga diferentes roles en diferentes empresas
        /// Ejemplos: "Admin", "Facturador", "Contador"
        /// </summary>
        [Required]
        [StringLength(50)]
        public string RoleInCompany { get; set; } = "Facturador";

        /// <summary>
        /// Indica si el usuario está activo en esta empresa
        /// </summary>
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Fecha en que el usuario fue asignado a esta empresa
        /// </summary>
        public DateTime AssignedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// ID del usuario que asignó este usuario a la empresa
        /// </summary>
        public string? AssignedByUserId { get; set; }

        /// <summary>
        /// Fecha de última actividad del usuario en esta empresa
        /// </summary>
        public DateTime? LastActivityAt { get; set; }

        // Navegación
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; } = null!;

        [ForeignKey("CompanyId")]
        public virtual Company Company { get; set; } = null!;

        [ForeignKey("AssignedByUserId")]
        public virtual ApplicationUser? AssignedBy { get; set; }
    }
}

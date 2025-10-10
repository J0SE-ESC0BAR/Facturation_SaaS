namespace WebApp.UI.Models
{
    /// <summary>
    /// Modelo para representar una empresa en el sistema
    /// </summary>
    public class Company
    {
        public int Id { get; set; }
        
        public string Name { get; set; } = string.Empty;
        
        public string RNC { get; set; } = string.Empty;
        
        public string Address { get; set; } = string.Empty;
        
        public string Phone { get; set; } = string.Empty;
        
        public string? Email { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public bool IsActive { get; set; } = true;
        
        // Navegación: Usuarios que pertenecen a esta empresa
        public virtual ICollection<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();
    }
}

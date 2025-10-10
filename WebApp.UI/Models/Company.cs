using System.ComponentModel.DataAnnotations;

namespace WebApp.UI.Models
{
    public class Company
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        [StringLength(20)]
        public string RNC { get; set; } = string.Empty;
        
        [Required]
        [StringLength(500)]
        public string Address { get; set; } = string.Empty;
        
        [StringLength(100)]
        public string? City { get; set; }
        
        [StringLength(100)]
        public string? State { get; set; }
        
        [StringLength(10)]
        public string? ZipCode { get; set; }
        
        [StringLength(100)]
        public string Country { get; set; } = "República Dominicana";
        
        [Required]
        [Phone]
        [StringLength(20)]
        public string Phone { get; set; } = string.Empty;
        
        [EmailAddress]
        [StringLength(100)]
        public string? Email { get; set; }
        
        [Url]
        [StringLength(200)]
        public string? Website { get; set; }
        
        public string? LogoUrl { get; set; }
        
        [StringLength(50)]
        public string? DGIICertificateNumber { get; set; }
        
        [StringLength(100)]
        public string? DGIIUsername { get; set; }
        
        public string? DGIIPassword { get; set; }
        
        [StringLength(20)]
        public string DGIIEnvironment { get; set; } = "Test";
        
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        [StringLength(450)]
        public string? CreatedByUserId { get; set; }
        
        public DateTime? UpdatedAt { get; set; }
        
        [StringLength(10)]
        public string? DefaultInvoiceSeries { get; set; }
        
        public int NextInvoiceNumber { get; set; } = 1;
        
        [StringLength(10)]
        public string? DefaultCreditNoteSeries { get; set; }
        
        public int NextCreditNoteNumber { get; set; } = 1;
        
        public virtual ICollection<UserCompany> UserCompanies { get; set; } = new List<UserCompany>();
        public virtual ApplicationUser? CreatedBy { get; set; }
        public virtual ICollection<Invoice>? Invoices { get; set; }
        public virtual ICollection<Client>? Clients { get; set; }
        public virtual ICollection<Product>? Products { get; set; }
    }
}

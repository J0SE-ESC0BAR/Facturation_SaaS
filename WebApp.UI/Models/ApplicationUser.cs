using Microsoft.AspNetCore.Identity;

namespace WebApp.UI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? LastLoginAt { get; set; }
        public bool IsActive { get; set; } = true;
        public string? GoogleId { get; set; }
        public string? MicrosoftId { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool IsFirstLogin { get; set; } = true;
        public int? ActiveCompanyId { get; set; }
        
        public string FullName => $"{FirstName} {LastName}".Trim();
        
        public string Initials
        {
            get
            {
                var first = !string.IsNullOrEmpty(FirstName) ? FirstName.Substring(0, 1).ToUpper() : "";
                var last = !string.IsNullOrEmpty(LastName) ? LastName.Substring(0, 1).ToUpper() : "";
                return first + last;
            }
        }
        
        public virtual ICollection<UserCompany> UserCompanies { get; set; } = new List<UserCompany>();
        public virtual Company? ActiveCompany { get; set; }
    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp.UI.Models;

namespace WebApp.UI.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceLine> InvoiceLines { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<UserCompany> UserCompanies { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>(entity =>
            {
                entity.Property(e => e.FirstName).HasMaxLength(100);
                entity.Property(e => e.LastName).HasMaxLength(100);
                entity.Property(e => e.GoogleId).HasMaxLength(100);
                entity.Property(e => e.MicrosoftId).HasMaxLength(100);
                
                entity.HasOne(e => e.ActiveCompany)
                    .WithMany()
                    .HasForeignKey(e => e.ActiveCompanyId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasIndex(e => e.GoogleId);
                entity.HasIndex(e => e.MicrosoftId);
                entity.HasIndex(e => e.Email);
            });

            builder.Entity<Company>(entity =>
            {
                entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
                entity.Property(e => e.RNC).IsRequired().HasMaxLength(20);
                entity.Property(e => e.Address).IsRequired().HasMaxLength(500);
                entity.Property(e => e.Phone).IsRequired().HasMaxLength(20);
                entity.Property(e => e.Email).HasMaxLength(100);
                entity.Property(e => e.Country).HasMaxLength(100).HasDefaultValue("República Dominicana");
                entity.Property(e => e.DGIIEnvironment).HasMaxLength(20).HasDefaultValue("Test");
                
                entity.HasOne(e => e.CreatedBy)
                    .WithMany()
                    .HasForeignKey(e => e.CreatedByUserId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(e => e.RNC).IsUnique();
                entity.HasIndex(e => e.IsActive);
            });

            builder.Entity<UserCompany>(entity =>
            {
                entity.HasKey(uc => new { uc.UserId, uc.CompanyId });

                entity.HasOne(uc => uc.User)
                    .WithMany(u => u.UserCompanies)
                    .HasForeignKey(uc => uc.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(uc => uc.Company)
                    .WithMany(c => c.UserCompanies)
                    .HasForeignKey(uc => uc.CompanyId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(uc => uc.AssignedBy)
                    .WithMany()
                    .HasForeignKey(uc => uc.AssignedByUserId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.Property(uc => uc.RoleInCompany).IsRequired().HasMaxLength(50);
                entity.Property(uc => uc.IsActive).HasDefaultValue(true);

                entity.HasIndex(uc => uc.IsActive);
                entity.HasIndex(uc => uc.RoleInCompany);
            });

            builder.Entity<Client>(entity =>
            {
                entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
                entity.Property(e => e.TaxId).IsRequired().HasMaxLength(20);
                entity.Property(e => e.IdType).HasMaxLength(20).HasDefaultValue("RNC");
                entity.Property(e => e.Country).HasMaxLength(100).HasDefaultValue("República Dominicana");
                entity.Property(e => e.CreditLimit).HasPrecision(18, 2);
                entity.Property(e => e.Balance).HasPrecision(18, 2);

                entity.HasOne(e => e.Company)
                    .WithMany(c => c.Clients)
                    .HasForeignKey(e => e.CompanyId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.CreatedBy)
                    .WithMany()
                    .HasForeignKey(e => e.CreatedByUserId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(e => new { e.CompanyId, e.TaxId }).IsUnique();
                entity.HasIndex(e => e.IsActive);
            });

            builder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Code).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Type).IsRequired().HasMaxLength(20).HasDefaultValue("Product");
                entity.Property(e => e.Unit).HasMaxLength(50).HasDefaultValue("Unidad");
                entity.Property(e => e.TaxRate).HasPrecision(5, 2).HasDefaultValue(18m);
                entity.Property(e => e.UnitPrice).HasPrecision(18, 2);
                entity.Property(e => e.Cost).HasPrecision(18, 2);
                entity.Property(e => e.Stock).HasPrecision(18, 4);
                entity.Property(e => e.MinimumStock).HasPrecision(18, 4);

                entity.HasOne(e => e.Company)
                    .WithMany(c => c.Products)
                    .HasForeignKey(e => e.CompanyId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.CreatedBy)
                    .WithMany()
                    .HasForeignKey(e => e.CreatedByUserId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(e => new { e.CompanyId, e.Code }).IsUnique();
                entity.HasIndex(e => e.IsActive);
                entity.HasIndex(e => e.Barcode);
            });

            builder.Entity<Invoice>(entity =>
            {
                entity.Property(e => e.InvoiceNumber).IsRequired().HasMaxLength(50);
                entity.Property(e => e.NCF).HasMaxLength(50);
                entity.Property(e => e.Status).IsRequired().HasMaxLength(20).HasDefaultValue("Draft");
                entity.Property(e => e.Subtotal).HasPrecision(18, 2);
                entity.Property(e => e.TaxAmount).HasPrecision(18, 2);
                entity.Property(e => e.DiscountAmount).HasPrecision(18, 2);
                entity.Property(e => e.Total).HasPrecision(18, 2);
                entity.Property(e => e.AmountPaid).HasPrecision(18, 2);
                entity.Property(e => e.Balance).HasPrecision(18, 2);

                entity.HasOne(e => e.Company)
                    .WithMany(c => c.Invoices)
                    .HasForeignKey(e => e.CompanyId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Client)
                    .WithMany(c => c.Invoices)
                    .HasForeignKey(e => e.ClientId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.CreatedBy)
                    .WithMany()
                    .HasForeignKey(e => e.CreatedByUserId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.UpdatedBy)
                    .WithMany()
                    .HasForeignKey(e => e.UpdatedByUserId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(e => new { e.CompanyId, e.InvoiceNumber }).IsUnique();
                entity.HasIndex(e => e.NCF);
                entity.HasIndex(e => e.Status);
                entity.HasIndex(e => e.IssueDate);
            });

            builder.Entity<InvoiceLine>(entity =>
            {
                entity.Property(e => e.Description).IsRequired().HasMaxLength(500);
                entity.Property(e => e.Quantity).HasPrecision(18, 4);
                entity.Property(e => e.UnitPrice).HasPrecision(18, 2);
                entity.Property(e => e.Subtotal).HasPrecision(18, 2);
                entity.Property(e => e.DiscountPercentage).HasPrecision(5, 2);
                entity.Property(e => e.DiscountAmount).HasPrecision(18, 2);
                entity.Property(e => e.SubtotalAfterDiscount).HasPrecision(18, 2);
                entity.Property(e => e.TaxRate).HasPrecision(5, 2);
                entity.Property(e => e.TaxAmount).HasPrecision(18, 2);
                entity.Property(e => e.Total).HasPrecision(18, 2);

                entity.HasOne(e => e.Invoice)
                    .WithMany(i => i.InvoiceLines)
                    .HasForeignKey(e => e.InvoiceId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Product)
                    .WithMany(p => p.InvoiceLines)
                    .HasForeignKey(e => e.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(e => new { e.InvoiceId, e.LineNumber });
            });

            builder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.ReceiptNumber).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Amount).HasPrecision(18, 2);
                entity.Property(e => e.PaymentMethod).IsRequired().HasMaxLength(50).HasDefaultValue("Cash");
                entity.Property(e => e.Status).IsRequired().HasMaxLength(20).HasDefaultValue("Completed");

                entity.HasOne(e => e.Company)
                    .WithMany()
                    .HasForeignKey(e => e.CompanyId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Client)
                    .WithMany()
                    .HasForeignKey(e => e.ClientId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Invoice)
                    .WithMany(i => i.Payments)
                    .HasForeignKey(e => e.InvoiceId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.CreatedBy)
                    .WithMany()
                    .HasForeignKey(e => e.CreatedByUserId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(e => new { e.CompanyId, e.ReceiptNumber }).IsUnique();
                entity.HasIndex(e => e.PaymentDate);
                entity.HasIndex(e => e.Status);
            });
        }
    }
}

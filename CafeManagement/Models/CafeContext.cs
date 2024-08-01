using Microsoft.EntityFrameworkCore;

namespace CafeManagement.Models
{
    public class CafeContext : DbContext
    {
        public CafeContext(DbContextOptions<CafeContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Receipt> Receipts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Model konfigürasyonlarını burada yapabilirsiniz.
            modelBuilder.Entity<Product>()
               .Property(p => p.ProductName)
               .IsRequired() // Ürün adı zorunlu
               .HasMaxLength(100); // Maksimum uzunluk 100 karakter

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)"); // Fiyatın decimal formatında olması

            // Table model konfigürasyonu
            modelBuilder.Entity<Table>()
                .Property(t => t.TableNumber)
                .IsRequired(); // Masa numarası zorunlu

            // Receipt model konfigürasyonu
            modelBuilder.Entity<Receipt>()
                .Property(r => r.PurchaseDate)
                .IsRequired(); // Satın alma tarihi zorunlu

            modelBuilder.Entity<Receipt>()
                .Property(r => r.Quantity)
                .IsRequired(); // Miktar zorunlu
        }
    }
}


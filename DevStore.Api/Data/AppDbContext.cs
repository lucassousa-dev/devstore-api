using DevStore.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace DevStore.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(Product => Product.Price)
                .HasPrecision(18, 2);
        }
    }
}
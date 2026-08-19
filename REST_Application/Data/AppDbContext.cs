using Microsoft.EntityFrameworkCore;
using REST_Application.Models;

namespace REST_Application.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
        .Property(p => p.Price)
        .HasPrecision(18, 2);
        }

    }
}
